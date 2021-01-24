	protected void OnListDataBound(object sender, EventArgs e) 
	{
	    DropDownList dropdown = (DropDownList)sender;
		string userId = string.Empty;
		
		// Assign value for userId from FormView1.DataSource
		....
		
		// Check to select valid item
		ListItem foundItem = dropdown.Items.FindByValue(userId); 
		if (foundItem != null)
		{
			dropdown.SelectedValue = userId;
		}
		else
		{
			dropdown.SelectedValue = string.Empty;
		}
	}	
