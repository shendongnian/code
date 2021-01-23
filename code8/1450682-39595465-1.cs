    // Create a new DataTable object.
    DataTable table = new DataTable();
        
    // Declare a DataColumn
    DataColumn column;
    
    // Create the new DataColumn, set DataType, ColumnName and add then add to DataTable.    
    column = new DataColumn();
    column.DataType = System.Type.GetType("System.Int32");
    column.ColumnName = "id";
    table.Columns.Add(column);
    // I think that the line-by-line explanation is better for the purpose of this answer
    // you can of course do all of this in one row, assuming that you already have a datatable
    table.Columns.Add("id", typeof(int));
