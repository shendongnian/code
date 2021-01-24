    private Brush _color = new SolidColorBrush(Colors.Red);
    private double _thickness = 4.0;
    private int _previousSignificantPoint = 0;
    private Polyline _freeLine;
    private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // Capture mouse
        canvas.CaptureMouse();
        Point startPoint = e.GetPosition(canvas);
        _freeLine = new Polyline
        {
            StrokeDashCap = PenLineCap.Square,
            StrokeLineJoin = PenLineJoin.Round,
            Stroke = _color,
            StrokeThickness = _thickness
        };
        // Add first point
        _freeLine.Points.Add(startPoint);
        // make it the first "significant" point
        _previousSignificantPoint = 0;
        canvas.Children.Add(_freeLine);
    }
    private void canvas_MouseMove(object sender, MouseEventArgs e)
    {
        // Make sure the mouse is pressed and we have a polyline to work with
        if (_freeLine == null) return;
        if (e.LeftButton != MouseButtonState.Pressed) return;
        // Get previous significant point to determine distance
        Point previousPoint = _freeLine.Points[_previousSignificantPoint];
        Point currentPoint = e.GetPosition(canvas);
        // If we have a new significant point (distance > 10) remove all intermediate points
        if (Distance(currentPoint, previousPoint) > 10)
        {
            for(int i = _freeLine.Points.Count - 1; i > _previousSignificantPoint; i--)
                _freeLine.Points.RemoveAt(i);
            // and set the new point as the latest significant point
            _previousSignificantPoint = _freeLine.Points.Count;
        }
        _freeLine.Points.Add(currentPoint);
    }
    private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
        // release mouse capture
        canvas.ReleaseMouseCapture();
        _freeLine = null;
    }
    private static double Distance(Point pointA, Point pointB)
    {
        return Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2));
    }
