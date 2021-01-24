     private async void categoryItemsGV_ItemClick(object sender, ItemClickEventArgs e)
            {
    
                    var item = e.ClickedItem as ProductOptionLineModel;
                            GridView gv = sender as GridView;
                            gv.SelectedItems.Remove(item);
           }
