    Point _start;
    void CanvasContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => _start = Mouse.GetPosition(CanvasContainer);
    void CanvasContainer_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            var mouse = Mouse.GetPosition(CanvasContainer);
            Canvas.SetLeft(RectangleMarker, _start.X > mouse.X ? mouse.X : _start.X);
            Canvas.SetTop(RectangleMarker, _start.Y > mouse.Y ? mouse.Y : _start.Y);
            RectangleMarker.Width = Math.Abs(mouse.X - _start.X);
            RectangleMarker.Height = Math.Abs(mouse.Y - _start.Y);
        }
    }
