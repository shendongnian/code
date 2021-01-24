    public static DataTable CreateCleanData(DataTable source, params int[] keepColumns)
    {
        var cleanedDataTable = source.Clone(); // empty table but same columns
        
        for (int i = 0; i < cleanedDataTable.Columns.Count; i++)
        {
            if (!keepColumns.Contains(i))
                cleanedDataTable.Columns.RemoveAt(i);
        }
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
