    string colName = "LastChanged";
    var lastChangedColumnList = table.Columns.Cast<DataColumn>()
      .Where(c => c.ColumnName.StartsWith(colName) && c.ColumnName.Substring(colName.Length).All(char.IsDigit))
      .ToList();
    
    foreach(DataColumn col in lastChangedColumnList)
        table.Columns.Remove(col);
