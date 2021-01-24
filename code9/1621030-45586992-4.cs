      private DataTable CopyRowsFromSource(DataTable sourceTable, DataTable destinationTable)
      {
         foreach (DataRow row in sourceTable.Rows)
         {
            destinationTable.Rows.Add(row.ItemArray);
         }
    
           return destinationTable;
        }
