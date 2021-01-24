    public DataSet ReadToDataSet(string fileName)
    {
        
        using (var wb = new SLDocument(fileName))
        {
            var set = new DataSet(GenerateTitle(wb.DocumentProperties.Title));
            foreach (var wsName in wb.GetWorksheetNames())
            {
                var ws = wb.SelectWorksheet(wsName);
                // Select worksheet returns a bool, so if it comes back false, try the next worksheet instead.
                if (!ws) continue;
                // Statistics gives indecies of the first and last data cells
                var stats = wb.GetWorksheetStatistics();
                // There is a bug with the stats columns. Take the total number of elements available or the columns from the stats table, whichever is the smallest
                var newColumnIndex = stats.NumberOfCells < stats.NumberOfColumns
                                    ? stats.NumberOfCells
                                    : stats.NumberOfColumns;
                
                // Create a new DataTable for each worksheet
                var dt = new DataTable(wsName);
                var addDataColumns = true;
                // Scan each row
                for (var rowIdx = stats.StartRowIndex; rowIdx < stats.EndRowIndex; rowIdx++)
                {
                    var newRow = dt.NewRow();
                    // And each column for data
                    for (var colIdx = stats.StartColumnIndex; colIdx < newColumnIndex; colIdx++)
                    {
                        if (addDataColumns)
                            dt.Columns.Add();
                        newRow[colIdx - 1] = wb.GetCellValueAsString(rowIdx, colIdx);
                    }
                    addDataColumns = false;
                    dt.Rows.Add(newRow);
                } 
                set.Tables.Add(dt);
            }
            return set;
        }
    }
