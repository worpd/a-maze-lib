using System;

namespace Worpd.aMazeLib.Core
{
    public class Point2D: IEquatable<Point2D>
    {
        public int x { get; }

        public int y { get; }

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D Up()
        {
            return new Point2D(x, y + 1);
        }

        public Point2D Down()
        {
            return new Point2D(x, y - 1);
        }

        public Point2D Left()
        {
            return new Point2D(x - 1, y);
        }

        public Point2D Right()
        {
            return new Point2D(x + 1, y);
        }

        public Point2D TopLeft()
        {
            return new Point2D(x - 1, y + 1);
        }

        public Point2D TopRight()
        {
            return new Point2D(x + 1, y + 1);
        }

        public Point2D BottomLeft()
        {
            return new Point2D(x - 1, y - 1);
        }

        public Point2D BottomRight()
        {
            return new Point2D(x + 1, y - 1);
        }

        public override string ToString()
        {
            return base.ToString()+"("+x+","+y+")";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point2D) obj);
        }

        public bool Equals(Point2D point)
        {
            return (point.x == x) & (point.y == y);
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
}
