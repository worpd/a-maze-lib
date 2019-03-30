using NUnit.Framework;
using Worpd.aMazeLib.Core;

namespace Worpd.aMazeLib.Test.Core
{
    public class Point2DTest
    {
        private Point2D point;

        [SetUp]
        public void SetUp()
        {
            point = new Point2D(5, 5);
        }

        [Test]
        public void UpWorks()
        {
            Assert.AreEqual(point.Up(), new Point2D(5, 6));
        }

        [Test]
        public void DownWorks()
        {
            Assert.AreEqual(point.Down(), new Point2D(5, 4));
        }

        [Test]
        public void LeftWorks()
        {
            Assert.AreEqual(point.Left(), new Point2D(4, 5));
        }

        [Test]
        public void RightWorks()
        {
            Assert.AreEqual(point.Right(), new Point2D(6, 5));
        }

        [Test]
        public void TopRightWorks()
        {
            Assert.AreEqual(point.TopRight(), new Point2D(6, 6));
        }

        [Test]
        public void TopLeftWorks()
        {
            Assert.AreEqual(point.TopLeft(), new Point2D(4, 6));
        }

        [Test]
        public void BottomRightWorks()
        {
            Assert.AreEqual(point.BottomRight(), new Point2D(6, 4));
        }

        [Test]
        public void BottomLeftWorks()
        {
            Assert.AreEqual(point.BottomLeft(), new Point2D(4, 4));
        }
    }
}
