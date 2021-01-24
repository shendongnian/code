    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
        public bool Equals(int x, int y) => 
            X == x && Y == y;
    }
