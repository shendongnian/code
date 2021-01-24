    public static string GetCellValue(this DataGrid grid, DataGridRow row, string columnName)
    {
        int index = grid.Columns.Single(c => c.Header.ToString().ToUpper() == columnName.ToUpper()).DisplayIndex;
        DataGridCell dgc = GetCell(grid, row, index);
        string str = Convert.ToString(((TextBlock)dgc.Content).Text);
        return str;
    }
