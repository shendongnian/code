    private void MergeCellsInColumn(NSGridView grid, int column, int startingRow, int endingRow)
    {
        grid.MergeCells(new NSRange(column, 1), new NSRange(startingRow, endingRow - startingRow + 1));
    }
    private void MergeCellsInRow(NSGridView grid, int row, int startingColumn, int endingColumn)
    {
        grid.MergeCells(new NSRange(startingColumn, endingColumn - startingColumn + 1), new NSRange(row, 1));
    }
