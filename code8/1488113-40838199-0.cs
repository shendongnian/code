    private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
    {
    	FurnitureHome item = e.ClickedItem as FurnitureHome;
    	Furniture itemDetail = new Furniture();
    	DetailId.Text = item.ID;
    	itemDetail.ID = DetailId.Text;
    	this.Frame.Navigate(typeof(Furniture), itemDetail);
    }
