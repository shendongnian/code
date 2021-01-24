    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
        public Point IncrementX() => new Point(X + 1, Y);
        public Point IncrementY() => new Point(X, Y + 1);
        public Point Move(int dx, int dy) => new Point(X + dx, Y + dy);
    }
