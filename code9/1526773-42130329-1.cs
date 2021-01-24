	public DataTable ImportData(IDataReader reader)
	{
		DataTable table = new DataTable();
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("UserName", typeof(string));
		
		int rownum = 0;
		while (reader.Read())
		{
			++rownum;
			int? id = reader.AsInt32(0);
			if (id == null)
				throw new Exception(string.Format("Invalid ID on row {0}, value: {1}", rownum, reader.GetValue(0)));
	
			string name = reader.AsString(1);
			
			table.Rows.Add(id.Value, name);
		}
		
		return table;
	}
