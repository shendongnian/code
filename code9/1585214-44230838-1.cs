    private void CodeListView_SelectionChanged(object sender, 
        SelectionChangedEventArgs e)
    {
        var listView = sender as ListView;
        var selectedCodes = listView.SelectedItem as Codes;
        if (selectedCodes != null)
        {
            //  Do stuff with selectedCodes
        }
    }
