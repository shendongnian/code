    private void GetRowsByFilter()
    {
        DataTable yourDataTable = new DataTable(); //Your DataTable is supposed to have the data
        // Presuming the DataTable has a column named user.
        string expression;
        expression = "user = \"msalmon\"";
        DataRow[] foundRows;
    
        // Use the Select method to find all rows matching the filter.
        foundRows = table.Select(expression);
    
        // Print column 0 of each returned row.
        for(int i = 0; i < foundRows.Length; i ++)
        {
            Console.WriteLine(foundRows[i][0]);
        }
    }
