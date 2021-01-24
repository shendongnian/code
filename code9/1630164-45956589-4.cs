    public static DataGridCell GetCell(this DataGrid grid, int row, int column)
    {
         DataGridRow rowContainer = grid.GetRow(row);
         return grid.GetCell(rowContainer, column);
    }
