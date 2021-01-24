	var dt = new DataTable();
	dt.Columns.Add(new DataColumn { ColumnName = "Code", AutoIncrement = true, DataType = typeof(int) });
	dt.Columns.Add(new DataColumn { ColumnName = "Resource Type", DataType = typeof(string) });
	dt.Columns.Add(new DataColumn { ColumnName = "Number of hits", DataType = typeof(int) });
	
	var newRow = dt.NewRow();
	newRow[1] = "Testing";
	newRow[2] = 3;
	
	dt.Rows.Add(newRow);
	var newRow2 = dt.NewRow();
	newRow2[1] = "Testing 2";
	newRow2[2] = 6;
	dt.Rows.Add(newRow2);
