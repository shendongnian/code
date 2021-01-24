    DataTable dtSchema = reader.GetSchemaTable();
    List<DataColumn> listCols = new List<DataColumn>();
    var rawData = new DataTable();
    if (dtSchema != null)
    {
    	foreach (DataRow drow in dtSchema.Rows)
    	{
    		string columnName = System.Convert.ToString(drow["ColumnName"]);
    		DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
    		column.Unique = false;
    		column.AllowDBNull = true;
    		column.AutoIncrement = false;
    		
    		listCols.Add(column);
    		rawData.Columns.Add(column);
    	}
    }
    while (reader.Read())
    {
    	DataRow dataRow = rawData.NewRow();
    	for (int i = 0; i < listCols.Count; i++)
    	{
    		dataRow[((DataColumn)listCols[i])] = reader[i];
    	}
    	rawData.Rows.Add(dataRow);
    }
