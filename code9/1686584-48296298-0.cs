    private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        var gridView = (GridView)sender;
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            var selectedItem = gridView.SelectedItem;
            //do something
        }
    }
