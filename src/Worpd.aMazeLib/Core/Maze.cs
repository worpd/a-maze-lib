using System;
using System.Collections.Generic;

namespace Worpd.aMazeLib.Core
{
    public class Maze
    {
        public int width { get; }
        public int height { get; }

        public MazeCellCollection walls;

        public Maze(int h, int w)
        {
            width = w;
            height = h;
            walls = new MazeCellCollection();
        }
        public bool hasWallAt(Point2D point)
        {
            return walls.hasWallAt(point);
        }

        public void addWall(MazeWall wall)
        {
            walls.addWall(wall);
        }
        public void removeWall(MazeWall wall)
        {
            walls.removeWall(wall);
        }

        public override string ToString()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Point2D point = new Point2D(x, y);
                    if (hasWallAt(point))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" x ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            return base.ToString();
        }
    }
}
