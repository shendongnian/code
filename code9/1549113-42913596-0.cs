	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		// Convert to non-generic list
		var list = value as IList;
		// ...
		var table = new DataTable();
		table.Columns.Add(...)
		// ... 
		foreach (var item in list)
		{
			var row = table.NewRow();
			// Convert list item to non-generic array
			var array = item as Array;
			
			// Iterate the array elements
			for (var i = 0; i < array.Length; i++)
			{
				row[i] = array.GetValue(i);
			}
			
			table.Rows.Add(row);
		}
	}
