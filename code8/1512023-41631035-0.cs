        public struct Point
        {
            public int X, Y { get; }
            public Point(int x, int y)
            {
            }
        }
        public bool Validate() { return -1000 <= X && X <= 1000 && -1000 <= Y and Y <= 1000; }
    Of course you could do the same using a property.
