    public static DataTable CreateCleanData(DataTable source, params int[] keepColumns)
    {
        var cleanedDataTable = source.Clone(); // empty table but same columns
        
        var removeColumns = cleanedDataTable.Columns.Cast<DataColumn>()
           .Where(c => !keepColumns.Contains(c.Ordinal));
        foreach (DataColumn c in removeColumns)
            cleanedDataTable.Columns.Remove(c);
        cleanedDataTable.BeginLoadData();
        foreach (DataRow sourceRow in source.Rows)
        {
            DataRow newRow = cleanedDataTable.Rows.Add();
            foreach (DataColumn c in cleanedDataTable.Columns)
            {
                newRow.SetField(c, sourceRow[c.ColumnName]);
            }
        }
        cleanedDataTable.EndLoadData();
        return cleanedDataTable;
    }
