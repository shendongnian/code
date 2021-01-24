    DataTable mergedTable = new DataTable();
    List<DataTable> tableCollection = new List<DataTable>();
    /*---------------------------------*/
	bool columnsAdded = false;
	foreach (DataTable table in tableCollection)
	{
		if (!columnsAdded)
		{
			foreach (DataColumn column in table.Columns)
			{
				mergedTable.Columns.Add(column);
			}
			columnsAdded = true;
		}
		foreach (DataRow row in table.Rows)
		{
			mergedTable.Rows.Add(row);
		}
	}
