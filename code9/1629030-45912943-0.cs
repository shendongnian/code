    private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        var keyword = MainSearchBar.Text;
        NameslistView.ItemsSource = kontakter.Where(obj =>( obj .Fuldenavn.Contains(keyword) || obj .Tlfnr.ToString().Contains(keyword)));
    }
