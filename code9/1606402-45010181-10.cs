    public struct Segment2D
    {
        public Point2D Start { get; }
        public Point2D End { get; }
        public double Argument => Math.Atan2(End.Y - Start.Y , End.X - Start.X);
        public Segment2D(Point2D start, Point2D end)
        {
            Start = start;
            End = end;
        }
    }
