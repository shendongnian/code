    private static void OnPreviewMouseDownThunk(object sender, MouseButtonEventArgs e)
    {
        if(!e.Handled)
        {
            UIElement uie = sender as UIElement;
            if (uie != null)
            {
                uie.OnPreviewMouseDown(e);
            }
            else
            {
                ContentElement ce = sender as ContentElement;
                if (ce != null)
                {
                    ce.OnPreviewMouseDown(e);
                }
                else
                {
                    ((UIElement3D)sender).OnPreviewMouseDown(e);
                }
            }
        }
        // Always raise this "sub-event", but we pass along the handledness.
        UIElement.CrackMouseButtonEventAndReRaiseEvent((DependencyObject)sender, e);
    }
    private static void CrackMouseButtonEventAndReRaiseEvent(DependencyObject sender, MouseButtonEventArgs e)
    {
        RoutedEvent newEvent = CrackMouseButtonEvent(e);
        if (newEvent != null)
        {
            ReRaiseEventAs(sender, e, newEvent);
        }
    }
    private static RoutedEvent CrackMouseButtonEvent(MouseButtonEventArgs e)
    {
        RoutedEvent newEvent = null;
        switch(e.ChangedButton)
        {
            case MouseButton.Left:
                if(e.RoutedEvent == Mouse.PreviewMouseDownEvent)
                    newEvent = UIElement.PreviewMouseLeftButtonDownEvent;
                else if(e.RoutedEvent == Mouse.MouseDownEvent)
                    newEvent = UIElement.MouseLeftButtonDownEvent;
                else if(e.RoutedEvent == Mouse.PreviewMouseUpEvent)
                    newEvent = UIElement.PreviewMouseLeftButtonUpEvent;
                else
                    newEvent = UIElement.MouseLeftButtonUpEvent;
                break;
            case MouseButton.Right:
                if(e.RoutedEvent == Mouse.PreviewMouseDownEvent)
                    newEvent = UIElement.PreviewMouseRightButtonDownEvent;
                else if(e.RoutedEvent == Mouse.MouseDownEvent)
                    newEvent = UIElement.MouseRightButtonDownEvent;
                else if(e.RoutedEvent == Mouse.PreviewMouseUpEvent)
                    newEvent = UIElement.PreviewMouseRightButtonUpEvent;
                else
                    newEvent = UIElement.MouseRightButtonUpEvent;
                break;
            default:
                // No wrappers exposed for the other buttons.
                break;
        }
        return ( newEvent );
    }
