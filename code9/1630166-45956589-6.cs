    public static string GetCellValue(this DataGrid grid, int rowIndex, string columnName)
    {
         DataGridRow row = grid.GetRow(rowIndex);
         int columnIndex = grid.Columns.Single(c => c.Header.ToString().ToUpper() == columnName.ToUpper()).DisplayIndex;
         DataGridCell dgc = GetCell(grid, row, columnIndex);
         string str = Convert.ToString((TextBlock)dgc.Content);
         return str;
    }
