    Point mousePos;
    Polyline polyline;
    double stepSize = 10; // Square size
    double stepSize2; // For precalculation (see below)
    public MainWindow()
    {
        InitializeComponent();
        polyline = new Polyline();
        polyline.Stroke = Brushes.Black;
        polyline.StrokeThickness = 4;
        polyline.Points = new PointCollection(); // Starts with an empty snake
        canvas.Children.Add( polyline );
        stepSize2 = stepSize * stepSize; // Precalculates the square (to avoid to repeat it each time)
    }
    protected override void OnMouseMove( MouseEventArgs e )
    {
        base.OnMouseMove( e );
        var newMousePos = e.GetPosition( canvas ); // Store the position to test
        if ( Dist2( newMousePos, mousePos ) > stepSize2 ) // Check if the distance is far enough
        {
            var dx = newMousePos.X - mousePos.X;
            var dy = newMousePos.Y - mousePos.Y;
            if ( Math.Abs( dx ) > Math.Abs( dy ) ) // Test in which direction the snake is going
                mousePos.X += Math.Sign( dx ) * stepSize;
            else
                mousePos.Y += Math.Sign( dy ) * stepSize;
            polyline.Points.Add( mousePos );
            if ( polyline.Points.Count > 50 ) // Keep the snake lenght under 50
                polyline.Points.RemoveAt( 0 );
        }
    }
    double Dist2( Point p1, Point p2 ) // The square of the distance between two points (avoids to calculate square root)
    {
        var dx = p1.X - p2.X;
        var dy = p1.Y - p2.Y;
        return dx * dx + dy * dy;
    }
