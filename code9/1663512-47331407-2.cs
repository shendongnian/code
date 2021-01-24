    var lst = table.Columns.Cast<DataColumn>()
         .Where(x => x.ColumnName.StartsWith("LastChanged"))
         .ToList();
    foreach(DataColumn col in lst){
          table.Columns.Remove(col);}
