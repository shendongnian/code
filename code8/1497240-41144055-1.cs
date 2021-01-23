    Microsoft.Office.Interop.Excel.Application xlApp;
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    Microsoft.Office.Interop.Excel.Range range;
    string str;
    xlApp = new Microsoft.Office.Interop.Excel.Application();
    xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\Admin\Desktop\testCell.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    range = xlWorkSheet.UsedRange;
    
    Microsoft.Office.Interop.Excel.Range last = xlWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
    
    int lastUsedRow = last.Row;
    int lastUsedColumn = last.Column;
    int lastColumn = -1;
    // Loop to find the last column containing text
    for(int i = lastUsedColumn; i > 0; i--)
    {
        if(xlWorkSheet.Application.WorksheetFunction.CountA(xlWorkSheet.Columns[i]) > 0)
        {
            lastColumn = i;
            break;
        }
    }
    int lastRow = -1;
    // Loop to find the last row containing text
    for (int i = lastUsedRow; i > 0; i--)
    {
        if (xlWorkSheet.Application.WorksheetFunction.CountA(xlWorkSheet.Rows[i]) > 0)
        {
            lastRow = i;
            break;
        }
    }
    Console.WriteLine("Last row containing text: " + lastRow);
    Console.WriteLine("Last column containing text: " + lastColumn);
    // Clear formatting of all columns from last cell with text to last cell in used range
    // For columns, you will 
    xlWorkSheet.Range[xlWorkSheet.Cells[lastRow, lastColumn+1], xlWorkSheet.Cells[lastUsedRow, lastUsedColumn]].ClearFormats();
    // Clear formatting of all rows from last cell with text to last cell in used range
    xlWorkSheet.Rows[(lastRow+1) + ":" + lastUsedRow].ClearFormats();
    Console.ReadLine();
    xlWorkBook.Close(true);
    xlApp.Quit();
