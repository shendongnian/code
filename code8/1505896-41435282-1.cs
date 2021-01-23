	DataTable table = new DataTable();
	table.Columns.Add("Emp ID");
	//Add All your columns
	var lines = File.ReadAllLines(txtFilePath.Text).ToList();
	lines.ForEach(line => table.Rows.Add(line.Split((char)9)));
	//Till the data has been already there in your DataTable. 
	//Create a new DataTable for Filtered Records.
	DataTable FilteredTable = new DataTable();
	//The Statement works like a SQL Statement which is equal to
	//Select * from TableName Where DateColumn Between two dates. 
	DataRow[] rows = table.Select("date >= #" + from_date + "# AND date <= #" + to_date + "#");
	//Now add all rows to the new Table.
	foreach (DataRow dr in rows) 
	{
		FilteredTable.ImportRow(dr);
	}
    dataGridView1.DataSource = FilteredTable;
