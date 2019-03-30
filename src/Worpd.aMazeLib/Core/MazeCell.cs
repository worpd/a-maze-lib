using System.Collections.Generic;

namespace Worpd.aMazeLib.Core
{
    public class MazeCell
    {
        public Point2D point { get; }
        public MazeCell(Point2D point)
        {
            this.point = point;
        }
    }
    public class MazeWall: MazeCell
    {
        public MazeWall(Point2D point): base(point) {}
    }
    public class MazeEntrance: MazeCell
    {
        public MazeEntrance(Point2D point): base(point) {}
    }
    public class MazeExit: MazeCell
    {
        public MazeExit(Point2D point): base(point) {}
    }
    public class MazeCellCollection
    {
        private Dictionary<Point2D, MazeWall> walls;
        public MazeCellCollection()
        {
            walls = new Dictionary<Point2D, MazeWall>();
        }
        public void addWall(MazeWall wall)
        {
            walls.Add(wall.point, wall);

        }
        public void removeWall(MazeWall wall)
        {
            walls.Remove(wall.point);
        }
        public bool hasWallAt(Point2D point)
        {
            return walls.ContainsKey(point);
        }
    }
}
