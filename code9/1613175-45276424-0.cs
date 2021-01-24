    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
    	if (e.Item.ItemType == ListViewItemType.DataItem)
    	{
    
    		ListViewDataItem dataItem = (ListViewDataItem)e.Item;
    		if (dataItem.DisplayIndex == ListView1.EditIndex)
    		{
    		TextBox tb = e.Item.FindControl("tbFK_MenuID") as TextBox;
    		}
    	}
    }
