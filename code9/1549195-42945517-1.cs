	public static DataTable ConvertToTableAutomatic<T>(IEnumerable<T> items)
	{
		DataTable dt = new DataTable();
		
		var properties = typeof(T).GetProperties();
		foreach (var property in properties)
			dt.Columns.Add(property.Name);
		
		foreach (var item in items)
			dt.Rows.Add(FillRow<T>(dt.NewRow(), item, properties));
		
		return dt;
	}
	
	private static DataRow FillRow<T>(DataRow row, T item, PropertyInfo[] properties)
	{
		foreach (var property in properties)
			row[property.Name] = property.GetValue(item);
	
		return row;
	}
