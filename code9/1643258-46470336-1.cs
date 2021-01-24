    private void DrawLine(Polygon myPolygon, int linePos)
    {
        var clip = new StreamGeometry();
        using (var context = clip.Open())
        {
            context.BeginFigure(myPolygon.Points.First(), true, true);
            context.PolyLineTo(myPolygon.Points.Skip(1).ToList(), true, false);
        }
        var line = new Line()
        {
            X1 = 0,
            X2 = Width,
            Y1 = linePos,
            Y2 = linePos,
            Stroke = Brushes.Red,
            StrokeThickness = 2,
            Clip = clip
        };
        grid1.Children.Add(line);
    }
