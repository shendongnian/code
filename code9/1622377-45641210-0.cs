        private void btnInfoToLeft_Click(object sender, RoutedEventArgs e)
        {
            // Figure out which screen we're on
            var allScreens = Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);
            // Place dialog to left of window, but not past screen border
            InfoWindow info= new InfoWindow();
            info.Left = Math.Max(this.Left - info.Width - 10, thisScreen.WorkingArea.Left);
            info.Top = Math.Max(this.Top - info.Height - 10, thisScreen.WorkingArea.Top);
            info.Show();
        }
