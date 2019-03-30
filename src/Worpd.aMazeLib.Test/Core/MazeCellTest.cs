using NUnit.Framework;
using Worpd.aMazeLib.Core;

namespace Worpd.aMazeLib.Test.Core
{
    public class MazeCellTest
    {
        private MazeCell cell;
        private MazeWall wall;
        private MazeExit exit;
        private MazeEntrance entrance;
        private MazeCellCollection collection;

        [SetUp]
        public void SetUp()
        {
            cell = new MazeCell(new Point2D(1, 1));
            wall = new MazeWall(new Point2D(1, 1));
            exit = new MazeExit(new Point2D(1, 1));
            entrance = new MazeEntrance(new Point2D(1, 1));
            collection = new MazeCellCollection();
        }

        [Test]
        public void RepresentsPoint2D()
        {
            Assert.AreEqual(new Point2D(1, 1), cell.point);
            Assert.AreEqual(new Point2D(1, 1), wall.point);
            Assert.AreEqual(new Point2D(1, 1), exit.point);
            Assert.AreEqual(new Point2D(1, 1), entrance.point);
        }

        [Test]
        public void CanAddToMazeCellCollection()
        {
            collection.addWall(new MazeWall(new Point2D(1, 1)));
            Assert.True(collection.hasWallAt(new Point2D(1, 1)));
        }

        [Test]
        public void CanRemoveFromMazeCellCollection()
        {
            collection.addWall(new MazeWall(new Point2D(1, 1)));
            collection.removeWall(new MazeWall(new Point2D(1, 1)));
            Assert.False(collection.hasWallAt(new Point2D(1, 1)));
        }

        [Test]
        public void ReturnFalseWhenMazeCellCollectionHasNoWallAt()
        {
            collection.addWall(new MazeWall(new Point2D(1, 1)));
            Assert.False(collection.hasWallAt(new Point2D(2, 1)));
        }
    }
}
