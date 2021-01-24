    _isdown =false;
    private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
         _isdown =true;
    }
    private void Border_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if ( _isdown)
        {
             _isdown = false;
             Keyboard.Focus(sender as Border);
         }
    }
