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
    
            // If you'd like to loop through the columns instead...
            foreach (DataColumn column in csvDataTable.Columns)
            {
                if (row[column] != SomeTest)
                {
                    invalidated = true;
                }
            }
    
            // if any of the rules above marked this row as invalid then add to table
            if (invalidated)
            {			
    			// this will add a copy of the entire row from the original table
                invalidatedTable.Rows.Add(row.ItemArray);
    			
    			// if instead you'd like to edit the data first then do this
    			// Note: Depending on your data structure you may need to add nulls or values
    			// to columns to keep your tables with the same structure.
    			DataRow invalidRow = invalidatedTable.NewRow()
    			invalidRow["columnName"] = "someValue"
    			invalidatedTable.Rows.Add(invalidRow);
            }
    
        } // End Loop
    
        // Show the invalid rows on a form control
        SomeFunctionThatBindsDatatableToFormControl(invalidatedTable);
    }
