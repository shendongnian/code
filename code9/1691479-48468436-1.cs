    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        e.Handled = CaptureMouse();
    }
    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        if (IsMouseCaptured &&
            TryHitTest(e.GetPosition(this), out var column, out var row))
        {
            ReleaseMouseCapture();
            e.Handled = true;
            //
            // Raise 'TileClick' event with 'column' and 'row'. 
            //
        }
    }
    private (int x, int y) _lastHover;
    protected override void OnMouseMove(MouseEventArgs e)
    {
        TryHitTest(e.GetPosition(this), out var x, out var y);
        if (_lastHover.x != x || _lastHover.y != y)
            InvalidateVisual();
        _lastHover = (x, y);
    }
