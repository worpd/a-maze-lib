using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NUnit.Framework;
using Worpd.aMazeLib.Core;

namespace Worpd.aMazeLib.Test.Core
{
    public class MazeCellTest
    {
        private MazeCell cell;

        [SetUp]
        public void SetUp()
        {
            cell = new MazeCell(new Point2D(1, 1));
        }

        [Test]
        public void RepresentsPoint2D()
        {
            Assert.AreEqual(new Point2D(1, 1), cell.point);
        }
    }
}
