    public static Point ElementPointToScreenPoint(UIElement element, Point pointOnElement)
    {
        return element.PointToScreen(pointOnElement);
    }
    
    private void OnElementMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (MiddleClock is UIElement)
        {
            Point MiddleClockCor = ElementPointToScreenPoint(MiddleClock as UIElement, new Point(0, 0));
        }
    }
