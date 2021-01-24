    public static (double minX, double maxX, double minY, double maxY) 
    GetBounds(List<Point> pts)
    {
        return pts.Aggregate(
            (Int32.MaxValue, Int32.MinValue, Integer.MaxValue, Int32.MinValue),
            (acc, point) => 
            (
                Math.Min(point.X, acc.Item1),
                Math.Max(point.X, acc.Item2),
                Math.Min(point.Y, acc.Item3),
                Math.Max(point.Y, acc.Item4)
            ));
    }
