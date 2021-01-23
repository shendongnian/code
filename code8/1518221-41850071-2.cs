	foreach (RepeaterItem item in rptItems.Items)
	{
		var dataRow = dataTable.NewRow();
		
		if (item.ItemType == ListItemType.Item)
		{
			var textBox1 = (TextBox)item.FindControl("<<textboxId1>>");
			dataRow["<<columnname1>>"] = textBox1.Text;
			
			var textBox2 = (TextBox)item.FindControl("<<textboxId2>>");
			dataRow["<<columnname2>>"] = textBox2.Text;
			
			//And So On... to retrive values from all the textboxes inside the item and set values of appropriate columns in dataRow;
			
			var dropdownList = (DropDownList)item.FindControl("<<dropdownListId1>>")
			
			dataRow["<<somecolumn>>"] = dropdownList.SelectedValue;
			
			//Once values from all the controls of item are obtained and set in the dataRow;
			
			datatable.Rows.Add(dataRow);
		}
	}
