    private void ValidateRows(DataTable csvDataTable)
    {
    	DataTable invalidatedTable = new DataTable();
    
    	// Loop over all the rows in the datatable
    	foreach (DataRow row in csvDataTable.Rows)
    	{
    		bool invalidated = false;
    
    		// Check if id column is null
    		if (row["id"] == null)
    			invalidated = true;
            // Check some other column is not equal to some value
    		if (row["columnName"].ToString() != "Whatever you consider valid")
    		{
    			invalidated = true;
    		}
    		
            // if any of the rules above marked this row as invalid then add to table
    		if (invalidated)
    		{
    			DataRow invalidRow = invalidatedTable.NewRow();
    			invalidatedTable.Rows.Add(invalidRow);
    		}
    
    	} // End Loop
    
        // Show the invalid rows on a form control
    	SomeFunctionThatBindsDatatableToFormControl(invalidatedTable);
    }
