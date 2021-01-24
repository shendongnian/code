    //Create a mapping
    List<Tuple<int, int>> columnMappings = new List<Tuple<int, int>>();
    for (int dt1ColumnIndex = 0; dt1ColumnIndex < dt1.Columns.Count; dt1ColumnIndex++)
    {
        string columnName = dt1.Columns[dt1ColumnIndex].ColumnName;
        if (dt2.Columns.Contains(columnName) == true)
        {
            int dt2ColumnIndex = dt2.Columns.IndexOf(columnName);
            columnMappings.Add(new Tuple<int, int>(dt1ColumnIndex, dt2ColumnIndex));
        }
    }
    
