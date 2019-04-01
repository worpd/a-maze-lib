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
            List<String> lines = new List<String>();

            for (int y = 0; y < height; y++)
            {
                List<String> line = new List<String>();

                for (int x = 0; x < width; x++)
                {
                    Point2D point = new Point2D(x, y);
                    if (hasWallAt(point))
                    {
                        line.Add(" x ");
                    }
                    else
                    {
                        line.Add(" . ");
                    }
                }

                lines.Add(String.Join("", line.ToArray()));
            }

            return String.Join("\n", lines.ToArray());
        }
    }
}
