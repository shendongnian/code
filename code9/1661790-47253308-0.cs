    private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Released)
        {
            toggle();
        }
        else if(e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
            RaiseEvent(new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left) 
            { 
                RoutedEvent = MouseLeftButtonUpEvent 
            });
        }
    }
