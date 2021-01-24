    private void SetUpUI()
    {
        var gridView = new GridView();
        //DataTemplate usage.
        gridView.ItemTemplate = (DataTemplate)App.Current.Resources["template"];
        gridView.ItemsSource = new List<string> { "fas", "fasd", "fasf" };
        RootLayout.Children.Add(gridView);
    }
