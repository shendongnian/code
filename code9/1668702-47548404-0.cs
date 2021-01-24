    using System.Linq
    ...
    foreach (RepeaterItem item in questionRepeater.Items)
    {
    	// Checking the item is a data item
    	if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
    	{
    		var rdbList = item.FindControl("CheckBoxList1") as CheckBoxList;
    		// Get the selected value
    		if (rdbList != null)
    		{
    			//get selected items' values 
    			List<string> selectedItems = rdbList.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .Select(li => li.Value)
                    .ToList();
    				
    			//add to your list of strings
    			retList.AddRange(selectedItems);
    		}
    	}
    }
