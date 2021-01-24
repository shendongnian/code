    private void btnHome_MouseUp(object sender, MouseButtonEventArgs e)
    {
         toggle();
    }
    private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
        RaiseEvent(new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left) 
        { 
            RoutedEvent = MouseLeftButtonUpEvent 
        });
    }
