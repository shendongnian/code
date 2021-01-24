    public struct Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point AdvanceOne() => new Point(X + 1, Y);
        public Point StepUpOne() => new Point(X, Y + 1);
        public Point StepDownOne() => new Point(X, Y - 1);
        public static bool CanStepUp(IEnumerable<Point> points)
        {
            var previousTwo = points.Take(2).ToArray();
            if (previousTwo.Length < 2)
                return true;
            return previousTwo[1].Y <= previousTwo[0].Y;
        }
        public static bool CanStepDown(IEnumerable<Point> points)
        {
            var previousTwo = points.Take(2).ToArray();
            if (previousTwo.Length < 2)
                return true;
            return previousTwo[1].Y >= previousTwo[0].Y;
        }
        public override string ToString() => $"({X}; {Y})";
    }
