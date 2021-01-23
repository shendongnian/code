	DataTable table = new DataTable();
	table.Columns.Add("Emp ID");
	table.Columns.Add("Scan Time");
	table.Columns.Add("Undefined 1");
	table.Columns.Add("Undefined 2");
	table.Columns.Add("Undefined 3");
	table.Columns.Add("Undefined 4");
	var lines = File.ReadAllLines(txtFilePath.Text).ToList();
	lines.ForEach(line => table.Rows.Add(line.Split((char)9)));
	
	DataTable FilteredTable = new DataTable();
	DataRow[] rows = table.Select("date >= #" + from_date + "# AND date <= #" + to_date + "#");
	foreach (DataRow dr in rows) 
	{
		FilteredTable.ImportRow(dr);
	}
    dataGridView1.DataSource = FilteredTable;
