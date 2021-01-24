    private int number;
    
    private void categoryItemsGV_ItemClick(object sender, ItemClickEventArgs e)
    {
        var item = e.ClickedItem as ProductOptionLineModel;
        number = ProductOptionLineModels.IndexOf(item);
    }
    
    private void categoryItemsGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        categoryItemsGV.SelectRange(new ItemIndexRange(number, 1));
    }
