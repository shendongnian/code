      PathFigure figures = new PathFigure(new Point(10, 5),
        new PathSegment[]
        {
          new LineSegment(new Point(60,5), true),
          new LineSegment(new Point(35,5), false),
          new LineSegment(new Point(35,65), true),
          new LineSegment(new Point(10,65), false),
          new LineSegment(new Point(60,65), true),
        }, false);
      PathGeometry pg = new PathGeometry();
      pg.Figures.Add(figures);
      MyPath.Data = pg;
