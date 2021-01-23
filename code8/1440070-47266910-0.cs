    private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
                Window win = ((UserControl)sender).Parent as Window;
                if(win != null)
                {
                    win.WindowStyle = WindowStyle.None;
                    win.ResizeMode = ResizeMode.NoResize;
               
                }
            }
