    var table = new DataTable();
	table.Columns.Add( "Id", typeof(Int32) );
	table.Columns.Add( "Code", typeof(String) );
	table.Columns.Add( "Description", typeof(string) );
	table.Columns.Add( "Quantity", typeof(Int32) );
	table.Columns.Add( "ItemPrice", typeof(decimal) );
	table.Columns.Add( "SubTotal", typeof( decimal ), "Quantity*ItemPrice");
	table.Columns.Add( "Taxes", typeof( decimal ), "SubTotal*0.21");
	table.Columns.Add( "LineTotal", typeof( decimal ), "SubTotal + Taxes");
