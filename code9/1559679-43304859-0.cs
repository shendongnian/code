    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchParameter = txtSearch.Text.Trim().ToLower();
        var matchingvalues = articleList.Where(stringToCheck => stringToCheck.Title.ToLower().Contains(searchParameter)
            || stringToCheck.ArticleShortcut.ToLower().Contains(searchParameter)
            || stringToCheck.ArticleCode != null && stringToCheck.ArticleCode.Any(code => !string.IsNullOrEmpty(code.Code) && code.Code.Contains(searchParameter)));
        dtgArtikli.ItemsSource = matchingvalues;
    }
