    public static List<dynamic> ConvertToDataTable(DataTable dataTable)
    {
    	var result = new List<dynamic>();
    	foreach (DataRow row in dataTable.Rows)
    	{
    		dynamic dyn = new ExpandoObject();		
    		foreach (DataColumn column in dataTable.Columns)
    		{
    			var dic = (IDictionary<string, object>)dyn;
    			dic[column.ColumnName] = row[column];
    		}
    		result.Add(dyn);
    	}
    	return result;
    }
