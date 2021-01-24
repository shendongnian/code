        private void btnInfoToRight_Click(object sender, RoutedEventArgs e)
        {
            // Figure out which screen we're on
            var allScreens = Screen.AllScreens.ToList();
            var thisScreen = allScreens.SingleOrDefault(s => this.Left >= s.WorkingArea.Left && this.Left < s.WorkingArea.Right);
            // Place dialog to right of window, but not past screen border
            InfoWindow info = new InfoWindow();
            info.Left = Math.Min(this.Left + this.ActualWidth + 10, thisScreen.WorkingArea.Right - info.Width);
            info.Top = Math.Min(this.Top + this.ActualHeight + 10, thisScreen.WorkingArea.Bottom - info.Height);
            info.Show();
        }
