    private void Window_LocationChanged_1(object sender, EventArgs e)
    {        
        Point ptb = CntCtrl.PointToScreen(new Point(0, 0));
        Popup1.HorizontalOffset = ptb.X;
        Popup1.VerticalOffset = ptb.Y + CntCtrl.Height;
    }
    private void CntCtrl_Loaded_1(object sender, RoutedEventArgs e)
    {
        Popup1.IsOpen = true;
        Point ptb = CntCtrl.PointToScreen(new Point(0, 0));
        Popup1.HorizontalOffset = ptb.X;
        Popup1.VerticalOffset = ptb.Y + CntCtrl.Height;
    }
