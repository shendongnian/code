    private async Task LoadData()
    {
        // get data
        var response = await httpClient.GetAsync(url);
        // Convert to your objects
        articleImageFullFlipview.ItemsSource = data;
        articleImageGridView.ItemsSource = data;
    }
    
    private void articleImageGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var gridView = (GridView)sender;
        articleImageFullFlipview.SelectedIndex = gridView.SelectedIndex;
        // show or hide any controls
    }
        
