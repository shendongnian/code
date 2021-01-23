    var rowsCount = grid.BindingContext[grid.DataSource, grid.DataMember].Count;
    var columnsCount = ((DataGridTableStyle)(grid.GetType().GetField("myGridTable",
        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
        .GetValue(grid))).GridColumnStyles.Count;
    for (int row = 0; row < rowsCount; row++)
    {
        for (int column = 0; column < columnsCount; column++)
        {
            var value = grid[row, column];
        }
    }
