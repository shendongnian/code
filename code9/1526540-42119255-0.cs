    List<int> indexes = new List<int>();
    foreach (DataColumn column in dataTable.Columns)
    {
        if (column.ColumnName.Contains("Comm"))
        {
          indexes.Add(column.Ordinal);          
        }
    }
