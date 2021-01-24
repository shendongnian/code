    private bool _capture;
    private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            if (_capture)
            {
                DragMove();
                _capture = false;
            }
            else
            {
                System.Diagnostics.Debug.Write("some action...");
                _capture = true;
                btnHome.RaiseEvent(new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left)
                {
                    RoutedEvent = MouseDownEvent
                });
            }
        }
    }
