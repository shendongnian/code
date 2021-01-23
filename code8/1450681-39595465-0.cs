    // Create new DataTable and DataSource objects.
    DataTable table = new DataTable();
        
    // Declare DataColumn and DataRow variables.
    DataColumn column;
    
    // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.ColumnName = "id";
    table.Columns.Add(column);
