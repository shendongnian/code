    private void UpdateSelected(object selected)
    {
    	var selectedItem = selected as Item;
    	if (selectedItem != null)
    	{
    		var item = AllItems.SingleOrDefault(i => i.Id == selectedItem.Id);
    		if (item != null)
    		{
    			item.Approver = "New Approver";
    		}
    	}
    }
