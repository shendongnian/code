    foreach (DataRow playerDataRow in playerDataTable.Rows)
    {
        var myDic = new Dictionary<string, object>();
        foreach (DataColumn column in playerDataTable.Columns)
        {
            myDic.Add(column.ColumnName, playerDataRow[column]);
        }
    }
