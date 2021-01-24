    // your polygon as in the question
    var myPolygon = new Polygon();
    myPolygon.Stroke = Brushes.Black;
    myPolygon.Fill = Brushes.LightSeaGreen;
    myPolygon.StrokeThickness = 2;
    myPolygon.Points = new PointCollection(new Point[]
    {
        new Point(50,50),
        new Point(50,165),
        new Point(140,165),
        new Point(140,120),
        new Point(70,120),
        new Point(80,70),
        new Point(140,70),
        new Point(140,50)
    });
    grid1.Children.Add(myPolygon);
    // add a line at vertical position 80
    var linePos = 80;
    // prepare the clip geometry equal to the polygon by using the polygon points
    var clip = new StreamGeometry();
    using(var context = clip.Open())
    {
        context.BeginFigure(myPolygon.Points.First(), true, true);
        context.PolyLineTo(myPolygon.Points.Skip(1).ToList(), true, false);
    }
    // draw the line with some appropriate width
    var line = new Line()
    {
        X1 = 0, X2 = Width, Y1 = linePos, Y2 = linePos,
        Stroke = Brushes.Red, StrokeThickness = 2,
        Clip = clip
    };
    grid1.Children.Add(line);
