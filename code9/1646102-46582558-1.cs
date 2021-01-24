    private Point? startPoint;
    private void CanvasContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition((IInputElement)sender);
    }
    private void CanvasContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        startPoint = null;
    }
    private void CanvasContainer_MouseMove(object sender, MouseEventArgs e)
    {
        if (startPoint.HasValue)
        {
            selectionRect.Rect = new Rect(
                startPoint.Value, e.GetPosition((IInputElement)sender));
        }
    }
