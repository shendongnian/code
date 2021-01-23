    	var dg = new DataGrid();
	var tb = new TextBox();
	tb.ID = "myTextBox"
	foreach (DataGridItem item in dg.Items)
	{
		foreach (var cell in item.Cells)
		{
			TextBox val = (TextBox)item.FindControl("textboxid here");
			if (val.Text == tb.Text)
			{
				//do something here
			}
		}
	}
