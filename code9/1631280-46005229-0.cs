     Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open("X:\\Private\\DATA\\PROJECT DATA\\Database\\TETRA\\Master Captured List - TETRA.xlsx");
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)excelWorkbook.Sheets[sheetSpaces];
                excelApp.Visible = true;
                excelApp.ScreenUpdating = false;
                excelApp.DisplayAlerts = false;
                Excel.Range last = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                int lastUsedRow = last.Row;
                string lastCell = "B" + lastUsedRow.ToString();
                Excel.Range range = xlWorkSheet.get_Range("B1", lastCell);
        
                foreach (Excel.Range item in range.Cells)
                {
                    string text = (string)item.Text;
                    if (text == "A")
                    {
                      Console.Write("A was found in cell")
                    }
        
        }
