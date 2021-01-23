	protected DataTable GetData()
	{
		DataTable table = new DataTable();
		table.Columns.Add(new DataColumn("yValue"));
		table.Rows.Add(new object[] { 10 });
		table.Rows.Add(new object[] { 30 });
		table.Rows.Add(new object[] { 30 });
		return table;
	}
