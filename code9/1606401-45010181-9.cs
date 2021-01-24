    public struct Point2D //omitted equality logic
    {
        public double X { get; }
        public double Y { get; }
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString() => $"{X:N3}; {Y:N3}";
    }
