     protected void RadGrid1_NeedDataSource(object sender, 
    GridNeedDataSourceEventArgs e)
    {
	DataTable table = new DataTable();
	table.Columns.Add("ID", typeof(int));
	table.Columns.Add("Name");
	for (int i = 1; i <= 20; i++) {
		table.Rows.Add(i, "Name" + i.ToString());
	}
	RadGrid1.DataSource = table;
    }
    protected void RadGrid1_ItemDataBound1(object sender, GridItemEventArgs e)
    {
	if (e.Item.ItemType == GridItemType.Item | e.Item.ItemType == GridItemType.AlternatingItem) {
		dynamic item = (GridDataItem)e.Item;
		//Find the grid in the DetailTemplate Cell
		RadGrid subGrid = (RadGrid)item.DetailTemplateItemDataCell.FindControl("RadGrid2");
		// Get the current row datakey value
		int currentRowDataKeyValue = Convert.ToInt32(item.GetDataKeyValue("ID"));
		DataTable table = new DataTable();
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("Name");
		table.Columns.Add("Link");
		for (int i = 1; i <= 5; i++) {
			table.Rows.Add(i, "Row " + currentRowDataKeyValue.ToString + ": Link " + i.ToString, "https://www.google.com");
		}
		subGrid.DataSource = table;
		subGrid.DataBind();
	}
    }
