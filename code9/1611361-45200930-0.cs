	DataTable dt = getData();
	List<dynamic> expandoList = new List<dynamic>();
	foreach (DataRow row in dt.Rows)
	{
        //create a new ExpandoObject() at each row
		var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
		foreach (DataColumn col in dt.Columns)
		{
            //put every column of this row into the new dictionary
			expandoDict.Add(col.ToString(), row[col.ColumnName].ToString());
		}
        
        //add this "row" to the list
		expandoList.Add(expandoDict);
	}
