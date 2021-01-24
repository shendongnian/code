    // create new table to which you want copy the first table
    DataTable table2 = new DataTable();
    // now copy the columns from table to table2
    foreach (DataColumn column in table.Columns)
    {
        table2.Columns.Add(column.ColumnName);
    }
    // copy the all data from table to table2
    foreach (DataRow row in table.Rows)
    {
        // initialize the new row for your data
        List<string> rowData = new List<string>();
        // add your columns data to the new row
        foreach (DataColumn column in table.Columns)
        {
            rowData.Add(row[column.ColumnName].ToString());
        }
        // add the data row to the new DataTable (table2)
        table2.Rows.Add(rowData);
    }
