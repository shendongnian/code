    private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MainItem.IsSelected)
        {
            MyFrame.Navigate(typeof(HomePage));
        }
        else if (FavouritItem.IsEnabled)
        {
            MyFrame.Navigate(typeof(FavouritePage));
        }
    }
