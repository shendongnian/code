    <ListView x:Name="LV_Items"
              IsItemClickEnabled="True"
              ItemClick="LV_Items_ItemClick"
              >
    </ListView>
    private void LV_Items_ItemClick(object sender, ItemClickEventArgs e)
    {
        // Get instance of the model in the clicked ListViewItem
        MyModel myModel = (MyModel)e.ClickedItem;
        
        Image img = myModel.Image;
    }
