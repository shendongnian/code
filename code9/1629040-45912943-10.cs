    private void MainSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue == string.Empty)
        {
            NameslistView.ItemsSource = kontakter.Where(name => (name.Fuldenavn.Contains("")));
        }
    }
