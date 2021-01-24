    bool _isControlPressed = false;
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.LeftCtrl))
        {
            _isControlPressed = true;
        }
    }
    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.LeftCtrl))
        {
            _isControlPressed = false;
        }
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 1 && _isControlPressed)
        {
            //do something
        }
    }
