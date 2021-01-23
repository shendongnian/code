     private void ExportDataSetToOther(System.Data.DataTable dataTable, bool isActive)
     {
         string path = string.Empty;
         var lines = new List<string>();
         if (isActive )
         {
             path = savingFileName.Remove(savingFileName.LastIndexOf('\\') + 1);
             savingFileName = path + transactionName + DetailsOrSummary + (page + 1) +"."+ extention;// extention means .txt,.xlx,.one,.xlxs etc
             isActive = false;
             string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                         Select(column => column.ColumnName).
                                         ToArray();
    
             var header = string.Join(",", columnNames);
             lines.Add(header);
    
             var valueLines = dataTable.AsEnumerable()
                                .Select(row => string.Join(",", row.ItemArray));
             lines.AddRange(valueLines);
    
             File.WriteAllLines(savingFileName, lines);
         }
         else
         {
            var valueLines1 = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines1);
    
            File.AppendAllLines(savingFileName, lines);
    
         }
    
     }
