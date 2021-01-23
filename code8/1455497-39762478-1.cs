    private void gridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var item = gridView.ContainerFromItem(e.ClickedItem) as GridViewItem;
        var grid = item.ContentTemplateRoot as Grid;
        var std = grid.Resources["std"] as Storyboard;
        std.Begin();
    }
