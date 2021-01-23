    object[,] data = new object[dataTable.Rows.Count, dataTable.Columns.Count];
    for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
    {
        for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
        {
            data[rowIndex, colIndex] = dataTable.Rows[rowIndex][colIndex];
        }
    }
