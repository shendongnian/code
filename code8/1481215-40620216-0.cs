        txtFilePath.Text = openfile.FileName;
        
        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
        Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
        Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;
        
    int rowCount = excelRange.Rows.Count
    int colCount = excelRange.Columns.Count
    
    for(int i = 1; i <= rowCount; i++)
    {
        for(int j = 1; j <= colCount; j++)
        {
             double value = Convert.ToDouble(excelRange[i,j].Value2)
        }
    }
