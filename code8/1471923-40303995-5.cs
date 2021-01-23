      Point[] points =
      {
        new Point(60, 5),
        new Point(35, 5),
        new Point(35, 65),
        new Point(10, 65),
        new Point(60, 65),
      };
    
      PathFigure figures = new PathFigure();
      figures.StartPoint = new Point(10, 5);
      figures.Segments = new PathSegmentCollection(points.Select((p, i) => new LineSegment(p, i % 2 == 0)));
      PathGeometry pg = new PathGeometry();
      pg.Figures.Add(figures);
      MyPath.Data = pg;
