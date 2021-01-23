    var firstItem = listviewFeatures.Items.FirstOrDefault();
    if (firstItem == null)
    {
        // Nothing to convert to datatable so return
        return;
    }
    
    // We have items so lets initialize the table
    DataTable table = new DataTable();
    foreach (ColumnHeader header in listviewFeatures.Columns)
    {
          table.Columns.Add(header);
    }
    
    // Now lets add the rows
    foreach (ListViewItem item in listviewFeatures.Items)
    {
    
        // Create one row per row in listview
        var row = table.NewRow();
    
        // Traverse the listview by each column and fill the row
        foreach (ColumnHeader header in listviewFeatures.Columns)
        {
            row[header] = item.Text;
        }
    
        // Add row to table. It will add it to the end.
        table.Rows.Add(row);   
    }
