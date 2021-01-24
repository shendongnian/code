    foreach (DataColumn col in dataTable.Columns)
    {
           if (col.ColumnName.Contains("Comm"))
           {
             var index = col.Ordinal;          
           }
     }
