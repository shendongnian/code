	DataTable table = new DataTable();
	table.Columns.Add("ID", typeof(int));
	table.Columns.Add("VERSION", typeof(string));
	table.Columns.Add("ENTITY", typeof(string));
	table.Rows.Add(1, "01", "A01");
	table.Rows.Add(1, "01", "A02");
	table.Rows.Add(2, "01", "A01");
	table.Rows.Add(2, "01", "A02");
