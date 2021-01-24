    namespace ConsoleApplication1
    {
        [Flags]
        enum Wall
        {
            North = 1,
            South = 2,
            East  = 4,
            West  = 8
        }
        static class Program
        {
            static void Main(string[] args)
            {
                int grid = 10;
                var map=new Wall[grid, grid];
                // fill in values here ...
                if(map[1, 2].HasFlag(Wall.North))
                {
                    // cell (2, 3) has a wall in the north direction
                }
            }
        }
    }
