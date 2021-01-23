	DataTable laborerDataTable = GetTable(); 
	Dictionary<string, string> exploded = new Dictionary<string, string>();
	foreach(DataRow row in laborerDataTable.Rows)
	{
		exploded.Add(row.Field<string>(0), row.Field<string>(1));
	}
	
