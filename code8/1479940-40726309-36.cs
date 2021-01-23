    private static void DeleteRows(List<int> rowsToDelete, Microsoft.Office.Interop.Excel.Worksheet worksheet)
    {
        // the rows are sorted high to low - so index's wont shift
        List<int> NonEmptyRows = Enumerable.Range(1, rowsToDelete.Max()).ToList().Except(rowsToDelete).ToList();
        if (NonEmptyRows.Max() < rowsToDelete.Max())
        {
            // there are empty rows after the last non empty row
            Microsoft.Office.Interop.Excel.Range cell1 = worksheet.Cells[NonEmptyRows.Max() + 1,1];
            Microsoft.Office.Interop.Excel.Range cell2 = worksheet.Cells[rowsToDelete.Max(), 1];
            //Delete all empty rows after the last used row
            worksheet.Range[cell1, cell2].EntireRow.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);
        }    //else last non empty row = worksheet.Rows.Count
        foreach (int rowIndex in rowsToDelete.Where(x => x < NonEmptyRows.Max()))
        {
            worksheet.Rows[rowIndex].Delete();
        }
    }
    private static void DeleteCols(List<int> colsToDelete, Microsoft.Office.Interop.Excel.Worksheet worksheet)
    {
        // the cols are sorted high to low - so index's wont shift
        //Get non Empty Cols
        List<int> NonEmptyCols = Enumerable.Range(1, colsToDelete.Max()).ToList().Except(colsToDelete).ToList();
        if (NonEmptyCols.Max() < colsToDelete.Max())
        {
            // there are empty rows after the last non empty row
            Microsoft.Office.Interop.Excel.Range cell1 = worksheet.Cells[1,NonEmptyCols.Max() + 1];
            Microsoft.Office.Interop.Excel.Range cell2 = worksheet.Cells[1,NonEmptyCols.Max()];
            //Delete all empty rows after the last used row
            worksheet.Range[cell1, cell2].EntireColumn.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftToLeft);
        }            //else last non empty column = worksheet.Columns.Count
        foreach (int colIndex in colsToDelete.Where(x => x < NonEmptyCols.Max()))
        {
            worksheet.Columns[colIndex].Delete();
        }
    }
