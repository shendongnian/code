    for (int row = 0; i < rowCount; row++)
    {
        var colDic = new Dictionary<string, string>();
        baskets.Add(row, colDic);
        for (int col = 0; col < columnCount; col++)
        {
            var colName = users_table.Columns[row].ColumnName;
            var colValue = users_table.Rows[row][col].ToString();
            colDic.Add(colName, colValue);
        }
    }
