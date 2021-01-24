     private DataTable RemoveColumns(DataTable table, int startCol, int endCol)
     {
           var colsToRemove = new List<DataColumn>();
    
           for (var colCount = startCol; colCount <= endCol; colCount++)
           {
                colsToRemove.Add(table.Columns[colCount]);
           }
    
           foreach (DataColumn col in colsToRemove)
           {
                table.Columns.Remove(col);
           }
                
           return table;
    }
