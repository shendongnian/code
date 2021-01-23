        private void DeletePlayListButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var boundItem = button.DataContext as JonPlaylist;
            }
        }
