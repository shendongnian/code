    private Point? startPoint;
    private void CanvasContainer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var element = (UIElement)sender;
        element.CaptureMouse();
        startPoint = e.GetPosition(element);
    }
    private void CanvasContainer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ((UIElement)sender).ReleaseMouseCapture();
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
