    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    string fileName = "YOUR_EXCEL_FILE";
    
    xlApp = new Excel.Application();
    xlWorkBook = xlApp.Workbooks.Open(fileName);
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
    for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
    {
        for (int j = 0; j < dataGridView3.Columns.Count; j++)
        {
            xlWorkSheet.Cells[i + 4, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();
        }
    }
    
    xlWorkBook.SaveAs(YOUR_PATH+ ".xlsx");
    object misValue = System.Reflection.Missing.Value;
    xlWorkBook.Close(true, misValue, misValue);
    xlApp.Quit();
    xlWorkSheet = null;
    xlWorkBook = null;
    xlApp = null;
    
    
    Process.Start("" + YOUR_PATH + ".xlsx");
