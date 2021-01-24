    void DrawPoly(IEnumerable<Point> points)
    {
        endpoints = points.Skip(1).Concat(new []{points.First()});
        pairs = points.Zip(endpoints, Tuple.Create);
        for(var pair in pairs)
        {
            DrawLine(pair.Item1, pair.Item2);
        }
    }
    void DrawLine(Point p1, Point p2)
    {
        // Your Bresenham code here
    }
