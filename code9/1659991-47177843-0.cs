    DataTable dtSource = new DataTable();
    DataTable dtTarget = new DataTable();
    
    // Get row at index == 6 (7th line as this is a 0-based-index)
    var headerRow = dtSource.Rows[6];
    
    // Iterate through all values
    foreach(var value in headerRow.ItemArray)
    {
        // For each value create a column
        // and add it to your new dataTable
        DataColumn dc = new DataColumn(value.ToString());
        dc.Caption = value.ToString();
        dtTarget.Columns.Add(dc);
    }
