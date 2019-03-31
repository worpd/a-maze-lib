using System;
using NUnit.Framework;
using Worpd.aMazeLib.Core;
using Worpd.aMazeLib.MazeGeneration;

namespace Worpd.aMazeLib.Test.MazeGeneration
{
    public class RandomDirectionMazeBuilderTest
    {
        private RandomDirectionMazeBuilder builder;

        [SetUp]
        public void SetUp()
        {
            builder = new RandomDirectionMazeBuilder();
        }

        [Test]
        public void BuilderIsCreated()
        {
            Assert.IsInstanceOf<RandomDirectionMazeBuilder>(builder);
        }

        [Test]
        public void ValidMazeIsBuilt()
        {
            Maze maze = builder.GenerateMaze(20, 20, new Random(5));
            Console.WriteLine(maze);
        }
    }
}
