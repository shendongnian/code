    namespace PositionTest
    {
        class Program
        {
            static void Main(string[] args) {
                Position mobpos = new Position { X = 1, Y = 2 };
                move(1, 4, mobpos);
            }
            public static void move(int x, int y, Position pos) {
                Position newpos = new Position { X = pos.X + x, Y = pos.Y + y };
                pos = newpos;
                Console.WriteLine("    " + pos.X + " " + pos.Y + "<old pos - new pos >" + newpos.X + " " + newpos.Y);
                Console.ReadLine();
            }
        }
        class Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
    Output:     2 6<old pos - new pos >2 6
