    DataTable table = new DataTable();
    
    table.Columns.Add("A", typeof(int));
    table.Columns.Add("B", typeof(string));
    
    table.Columns[0].ColumnName = "Column A";
    table.Columns[1].ColumnName = "Column B";
    
    table.Rows.Add(99, "test row");
