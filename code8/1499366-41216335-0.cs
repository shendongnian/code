    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace ExcelDemo
    {
        class Core
        {
            public static void Main(string[] args)
            {
                Excel.Application MyExcel = new Excel.Application();
                // MyExcel.Visible = false;
                Excel.Workbook MyWorkbook = null;
                object Missing = System.Reflection.Missing.Value;
                MyWorkbook = MyExcel.Workbooks.Open("C:\\Temp\\Document.xlsx");
                Excel.Sheets MySheets = MyWorkbook.Worksheets;
                Excel.Worksheet MyWorksheet = (Excel.Worksheet)MySheets.get_Item("Tabelle1");
                Excel.Range MyLast = MyWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range MyRange = MyWorksheet.get_Range("A1", MyLast);
                int MyLastRow = MyLast.Row;
                int MyLastColumn = MyLast.Column;
                MyLast.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                MyWorksheet.SaveAs("C:\\Temp\\Document_Edited.xlsx");
                MyWorkbook.Close(false, Missing, Missing);
                MyExcel.Quit();
            }
        }
    }
