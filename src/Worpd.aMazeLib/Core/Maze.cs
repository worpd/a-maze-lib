namespace Worpd.aMazeLib.Core
{
    public class Maze
    {
        public int width { get; }
        public int height { get; }

        public Maze(int h, int w)
        {
            width = w;
            height = h;
        }
    }
}
