    var lastChanged = table.Columns.Cast<DataColumn>()
      .Where(c => c.ColumnName.StartsWith("LastChanged"))
      .ToList();
    
    foreach(DataColumn col in lastChanged)
        table.Columns.Remove(col);
