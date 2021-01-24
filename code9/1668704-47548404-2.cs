    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
    {
    	var rdbList = item.FindControl("CheckBoxList1") as CheckBoxList;
    	// Get the selected value
    	if (rdbList != null)
    	{
    		foreach (ListItem li in rdbList.Items)
    		{
    			if (li.Selected)
    				retList.Add(li.Value);
    		}
    	}
    }
