    private int flag=0;
    private async void girdView_ItemClick(object sender, ItemClickEventArgs e)
    {
       var gridView = sender as GridView;
       if (e.ClickedItem == gridView.SelectedItem)
       {
           gridView.SelectedItem = null; 
       }
       flag = 1; 
    } 
    private void gridView_Tapped(object sender, TappedRoutedEventArgs e)
    {
       if (flag == 0)
       {
           var gridView = sender as GridView;
           gridView.SelectedItem = null;
           gridView.SelectedIndex = -1; 
       }
       else
       {
           flag = 0;
       }
    }
