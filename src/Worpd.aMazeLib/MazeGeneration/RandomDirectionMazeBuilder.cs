using System;
using System.Collections.Generic;
using Worpd.aMazeLib.Core;

namespace Worpd.aMazeLib.MazeGeneration
{
    public class RandomDirectionMazeBuilder
    {
        public Maze GenerateMaze(int w, int h, Random rnd, int maxIterations = 1000)
        {
            Console.WriteLine("Starting to generate maze");
            Maze maze = new Maze(w, h);
            FillMaze(maze);

            int randomY1 = (rnd.Next((h - 1) / 2) * 2) + 1;
            Point2D start = new Point2D(0, randomY1);

            CarveMaze(maze, start, rnd);

            List<Point2D> possibleBranches = GetPossibleNextBranches(maze);
            int iterations = 0;
            while (possibleBranches.Count > 0 & iterations < maxIterations)
            {
                iterations++;
                Console.WriteLine("Iterations: " + iterations);
                int randomIndex = rnd.Next(possibleBranches.Count);
                CarveMaze(maze, possibleBranches[randomIndex], rnd);

                possibleBranches = GetPossibleNextBranches(maze);
                Console.WriteLine("Possible Next Branches: " + possibleBranches.Count);
            }

            List<Point2D> possibleExits = GetPossibleExits(maze);
            if (possibleExits.Count == 0)
            {
                Console.WriteLine("Skipping maze exit because we have no possible nearby walls.");
            }
            else
            {
                int randomExitIndex = rnd.Next(possibleExits.Count);
                maze.removeWall(new MazeWall(possibleExits[randomExitIndex]));
            }

            return maze;
        }

        private void FillMaze(Maze maze)
        {
            for (int x = 0; x < maze.width; x++)
            {
                for (int y = 0; y < maze.height; y++)
                {
                    Point2D point = new Point2D(x, y);
                    MazeWall wall = new MazeWall(point);
                    maze.addWall(wall);
                }
            }
        }

        private void CarveMaze(Maze maze, Point2D current, Random rnd)
        {
            if (maze.hasWallAt(current))
            {
                MazeWall wall = new MazeWall(current);
                maze.removeWall(wall);
            }

            List<Point2D> possiblePoints = GetPossibleNextPoints(maze, current);
            Console.WriteLine("Possible Next Moves: " + possiblePoints.Count);

            if (possiblePoints.Count > 0)
            {
                int randomIndex = rnd.Next(possiblePoints.Count);
                Point2D nextPoint = possiblePoints[randomIndex];

                CarveMaze(maze, nextPoint, rnd);
            }
        }
        private List<Point2D> GetPossibleNextBranches(Maze maze)
        {
            List<Point2D> results = new List<Point2D>();

            for (int x = 1; x < maze.width - 1; x++)
            {
                for (int y = 1; y < maze.height - 1; y++)
                {
                    Point2D point = new Point2D(x, y);
                    if (maze.hasWallAt(point)) continue;

                    List<Point2D> possiblePoints = GetPossibleNextPoints(maze, point);
                    if (possiblePoints.Count > 0)
                    {
                        results.Add(point);
                        Console.WriteLine("Found Possible Branch: " + point);
                        foreach (Point2D possiblePoint in possiblePoints)
                        {
                            Console.WriteLine(possiblePoint);
                        }
                    }
                }
            }

            return results;
        }
        private List<Point2D> GetPossibleExits(Maze maze)
        {
            List<Point2D> results = new List<Point2D>();

            for (int y = 1; y < maze.height - 1; y++)
            {
                // If this one is not a wall, then we can have an exit to the right of it.
                Point2D point = new Point2D(maze.width - 2, y);
                if (!maze.hasWallAt(point)) results.Add(point.Right());
            }

            return results;
        }
        private List<Point2D> GetPossibleNextPoints(Maze maze, Point2D current)
        {
            List<Point2D> results = new List<Point2D>();

            Point2D up = current.Up();
            Point2D down = current.Down();
            Point2D left = current.Left();
            Point2D right = current.Right();

            if (isValidCarvePoint(maze, current, up)) results.Add(up);
            if (isValidCarvePoint(maze, current, down)) results.Add(down);
            if (isValidCarvePoint(maze, current, left)) results.Add(left);
            if (isValidCarvePoint(maze, current, right)) results.Add(right);

            return results;
        }
        private bool isValidCarvePoint(Maze maze, Point2D origin, Point2D option)
        {
            // Can't carve the outer wall of the maze or things out of bounds.
            if (option.x < 1) return false;
            if (option.y < 1) return false;
            // Has already been carved.
            if (!maze.hasWallAt(option)) return false;

            List<Point2D> pointsToCheck = new List<Point2D>() {
                // Check surrounding points
                option.Up(),
                option.Down(),
                option.Left(),
                option.Right(),
                // Also want the corner points
                option.TopLeft(),
                option.TopRight(),
                option.BottomLeft(),
                option.BottomRight()
            };

            foreach(Point2D point in pointsToCheck)
            {
                // Don't disqualify if we are looking at the origin
                if (point.Equals(origin)) continue;
                // Or something connected to the origin!
                if (point.Equals(origin.Up())) continue;
                if (point.Equals(origin.Down())) continue;
                if (point.Equals(origin.Left())) continue;
                if (point.Equals(origin.Right())) continue;
                // All other points should be walls?
                if (!maze.hasWallAt(point)) return false;
            }

            return true;
        }

    }
}
