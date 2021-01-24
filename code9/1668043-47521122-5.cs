    var a = pts.Aggregate(
         new {
            MinX = int.MaxValue,
            MaxX = int.MinValue,
            MinY = int.MaxValue,
            MaxY = int.MinValue
        },
        (acc, p) => new {
            MinX = Math.Min(p.X, acc.MinX);
            MaxX = Math.Max(p.X, acc.MaxX);
            MinY = Math.Min(p.Y, acc.MinY);
            MaxY = Math.Max(p.Y, acc.MaxY);
        });
