	Dictionary<string, object> defaults = new Dictionary<string, object>()
	{
		{ "CreatedDate", DateTime.MinValue },
		{ "full_name", "n/a" },
		{ "Id", default(int) },
	};
	
	foreach (DataColumn column in dt.Columns)
	{
		row[column] = defaults.ContainsKey(column.ColumnName) ? defaults[column.ColumnName] : 0;
	}
