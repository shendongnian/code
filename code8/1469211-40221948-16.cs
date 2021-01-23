    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var cv = CollectionViewSource.GetDefaultView(WatchedFilesTreeView.ItemsSource);
        cv.SortDescriptions.Clear();
        cv.SortDescriptions.Add(
            new System.ComponentModel.SortDescription("Name", 
                System.ComponentModel.ListSortDirection.Descending));
    }
