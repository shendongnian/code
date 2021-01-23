	void Main()
	{
		var dt1 = new DataTable();
		dt1.Columns.Add("col1", typeof(string));
		dt1.Columns.Add("col2", typeof(int));
		
		
		var dt2 = new DataTable();
		dt2.Columns.Add("col1", typeof(string));
		dt2.Columns.Add("col2", typeof(int));
			
		var row = dt1.NewRow();
		row["col1"] = "one";
		row["col2"] = 1;
		dt1.Rows.Add(row);
		
		row = dt1.NewRow();
		row["col1"] = "two";
		row["col2"] = 2;
		dt1.Rows.Add(row);
		
		row = dt2.NewRow();
		row["col1"] = "three";
		row["col2"] = 3;
		dt2.Rows.Add(row);
		
		row = dt2.NewRow();
		row["col1"] = "four";
		row["col2"] = 4;
		dt2.Rows.Add(row);
	
		
		var dtMerged = dt1.AsEnumerable().CopyToDataTable();	// Note: CopyToDataTable requirs that there are rows.  must trap for empty table
		dtMerged.Merge(dt2.AsEnumerable().CopyToDataTable(), true, MissingSchemaAction.Add);
		
		dtMerged.Dump();
	}
