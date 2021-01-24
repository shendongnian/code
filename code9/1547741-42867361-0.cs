	private void GridView_ItemClick(object sender, ItemClickEventArgs e)
	{
		GridViewItem item = myGridView.ContainerFromItem(e.ClickedItem) as GridViewItem;
		MyData newData = (MyData)e.ClickedItem;
		ImageEx ex = FindChildControl<ImageEx>(item, "ImageExControl") as ImageEx;
		ex.Source = newData.brandLogo;
	}
