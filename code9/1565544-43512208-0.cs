    DataTable table = new DataTable();
    List<int> rowsToRemove = new List<int>();
    for (int i = 0; i < table.Rows.Count; i++)
    {
    	DataRow row = table.Rows[i];
    	foreach (DataColumn col in row.Table.Columns)
    	{
    		bool skip = false;
    		if (row[col] != null)
    		{
    			//this column is not null, so mark skip flag as true
    			skip = true;
    			
    		}
    		if (skip)
    			//this row should be skipped because it has at least one column that isn't null
    			break;
    		else
    			rowsToRemove.Add(i);
    			//mark this row's index for deletion
    	}
    }
    
    //loop through list in reverse order and remove rows by their index
    for (int i = rowsToRemove.Count; i > 0; i--)
    	table.Rows.RemoveAt(i);
