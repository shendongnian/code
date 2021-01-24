    private void articleImageGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var gridView = (GridView)sender;
        articleImageFullFlipview.SelectedIndex = gridView.SelectedIndex;
        // show or hide any controls
    }
        
