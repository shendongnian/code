    foreach (DataColumn column in dataTable.Columns)
    {
	column.ColumnName = column.ColumnName.Replace(" ", "");
	column.ColumnName = column.ColumnName.Replace("_", "");
    }
	
