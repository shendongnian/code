    public void ChangeColumnHeaderVal()
    {
        MSExcel.Excel.ApplicationClass xlApp = null;
        MSExcel.Excel.Workbook xlBook = null;
        MSExcel.Excel.Sheets xlSheets = null;
        MSExcel.Excel.Worksheet xlSheet = null;
        try
        {
            // Open the file
            xlApp = new MSExcel.Excel.ApplicationClass();
            xlBook = xlApp.Workbooks.Open(sourceFilename, 0, false, 5, null, null, false, MSExcel.Excel.XlPlatform.xlWindows, null, true, false, 0, true, false, false);
            xlSheets = xlBook.Worksheets;
            xlSheet = (MSExcel.Excel.Worksheet)xlSheets.Item[1];
    
            // Change the file
            MSExcel.Excel.Range priceTypeCell = (MSExcel.Excel.Range)xlSheet.Cells[7, 3];
            if (priceTypeCell.Value2.ToString().Trim().Contains("Price Push"))
            {
                priceTypeCell.Value2 = "Price Type";
            }
    
            // Save the file
            xlApp.DisplayAlerts = false; // Was prompting about overwriting the existing file
            xlBook.SaveAs(sourceFilename, Type.Missing, Type.Missing, Type.Missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlBook.Close();
        }
        finally
        {
            Marshal.ReleaseComObject(xlSheet);
            Marshal.ReleaseComObject(xlBook);
            xlApp.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
