        private void Window_Initialized(object sender, RoutedEventArgs e)
        {
            Rect r = App.Settings.MainWindowBounds;
            Rect desktop = new Rect(SystemParameters.VirtualScreenLeft, SystemParameters.VirtualScreenTop, SystemParameters.VirtualScreenWidth, SystemParameters.VirtualScreenHeight);
            if (desktop.Contains(r) && r.Width > 0.0 && r.Height > 0.0)
            {
                Left = r.Left;
                Top = r.Top;
                Height = r.Height;
                Width = r.Width;
            }
        }
