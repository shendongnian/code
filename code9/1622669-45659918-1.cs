    Point mypoint;
    Point tg;
    var pointCollection = new List<Point>();
        for (var i = 0; i < 500; i++)
            {
               SomePath.Data.GetFlattenedGeometryPath()
                             .GetPointAtFractionLength(i / 500f, out mypoint, out tg);
                pointCollection.Add(p);
            }
