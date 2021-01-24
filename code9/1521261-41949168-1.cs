    for (int row = 0; i < rowCount; row++)
    {
        baskets.Add(row, new Dictionary<string, string>());
        for (int col = 0; col < columnCount; col++)
        {
            var colName = (users_table.Columns[row].ColumnName).ToString();
            var colValue = users_table.Rows[row][col].ToString();
            baskets[row].Add(colName, colValue);
            Response.Write(baskets[row]["user_id"].ToString());
        }
    }
