    DataTable table = GetTable(); // Get the data table.
	foreach (DataRow row in table.Rows) // Loop over the rows.
	{
	  var dt = new DateTime(long.Parse(row["ColumnName"].ToString())); // parse to datetime 
    }
