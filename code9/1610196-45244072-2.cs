     protected void RadGrid1_NeedDataSource(object sender, 
     GridNeedDataSourceEventArgs e)
     {
	     DataTable table = new DataTable();
	    table.Columns.Add("ID", typeof(int));
	    table.Columns.Add("Name");
	    for (int i = 1; i <= 5; i++) {
	 	    table.Rows.Add(i, "Name" + i.ToString());
	    }
	   RadGrid1.DataSource = table;
      }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
	    if (e.CommandName.StartsWith("Export")) {
	     	if (!String.IsNullOrEmpty(Request("_downloadToken"))) {
	     		Response.Cookies.Add(new HttpCookie("_downloadToken", 
                Request("_downloadToken")));		 
	 	    }
	    }
    }
