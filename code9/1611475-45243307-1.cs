    protected void RadGrid3_NeedDataSource(object sender, 
    GridNeedDataSourceEventArgs e)
    {
        //Populate parent table with temp data
	    DataTable table = new DataTable();
	    table.Columns.Add("ID", typeof(int));
	    table.Columns.Add("Name");
	    for (int i = 1; i <= 20; i++) {
	    	table.Rows.Add(i, "Name" + i.ToString());
	    }
	RadGrid3.DataSource = table;
     }
    protected void RadGrid3_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //If its a row item
	    if (e.Item.ItemType == GridItemType.Item | e.Item.ItemType == GridItemType.AlternatingItem) {
		dynamic item = (GridDataItem)e.Item;
       
        //Find the nested Radgrid in the row
		RadGrid subGrid = (RadGrid)item("Links").FindControl("RadGrid4");
        //Get the current row's datakey value
        int currentRowDataKeyValue = item.GetDataKeyValue("ID");
        //Create temp data for nested radgrid
		DataTable table = new DataTable();
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("Name");
		table.Columns.Add("Link");
		for (int i = 1; i <= 5; i++) {
			table.Rows.Add(i, "Row " + currentRowDataKeyValue.ToString + ": Link " + i.ToString, "https://www.google.com");
		}
        
        //Set datasource for nested radgrid. This is where you would databind the list of strings from your domain. You will probably need to manipulate the data returned to match the nested grid structure if you want additional columns
		subGrid.DataSource = table;
		subGrid.DataBind();
	}
    
