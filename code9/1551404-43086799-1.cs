    private async void categoryItemsGV_ItemClick(object sender, ItemClickEventArgs e)
            {
    
                    var item = e.ClickedItem as ProductOptionLineModel;
                                await   _viewModel.DialogService("FirstRequireMinOption", "", true);
                                GridView gv = sender as GridView;
                                gv.SelectedItems.Add(item);
           }
