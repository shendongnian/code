    var figure = new PathFigure
    {
        StartPoint = new Point(0, 0),
        IsClosed = true
    };
    figure.Segments.Add(new PolyLineSegment
    {
        Points = new PointCollection { new Point(0, 100), new Point(150, 150) },
        IsStroked = true
    });
    var geometry = new PathGeometry();
    geometry.Figures.Add(figure);
    var path = new Path
    {
        Data = geometry,
        Stroke = Brushes.LightBlue,
        StrokeThickness = 2,
        Fill = Brushes.Green,
        Opacity = 0.5
    };
