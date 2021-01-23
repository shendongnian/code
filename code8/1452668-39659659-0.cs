    Excel.Application objexcel = new Microsoft.Office.Interop.Excel.Application();
    Excel.Workbook xlBook = objexcel.Workbooks.Open(filename);
    Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets.get_Item(1);
    range = xlSheet.UsedRange;
    Excel.Range last =xlSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
    range.get_Range("A2", last).Delete(XlDeleteShiftDirection.xlShiftUp);
