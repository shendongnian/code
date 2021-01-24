    private void CanvasEvent(object sender, RoutedEventArgs e)
    {
        // When drawing etc. starts, where the button should not handle the events
        isDrawing = true;  
    }
    private void ButtonEvent(object sender, RoutedEventArgs e)
    {
        if (isDrawing) { return; }
        // When not drawing do stuff
        ...
    }
