    int MinX, MaxX, MinY, MaxY;
    MaxX = MaxY = Int.MinValue;
    MinX = MinY = Int.MaxValue;
    foreach(Point p in pts)
    {
        MinX = Math.Min(p.X, MinX);
        MaxX = Math.Max(p.X, MaxX);
        MinY = Math.Min(p.Y, MinY);
        MaxY = Math.Max(p.Y, MaxY);
    }
    var a = new
        {
            MinY,
            MaxY,
            MinX,
            MaxX
        };
