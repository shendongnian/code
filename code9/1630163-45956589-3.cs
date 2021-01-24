    public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, string columnName)
    {
        int index = grid.Columns.Single(c => c.Header.ToString().ToUpper() == columnName.ToUpper()).DisplayIndex;
        return GetCell(grid, row, index);
    }
