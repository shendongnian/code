    public void ChangeColumnHeaderVal()
    {
        MSExcel.Excel.ApplicationClass xlApp = null;
        MSExcel.Excel.Workbook xlBook = null;
        MSExcel.Excel.Worksheet xlSheet = null;
        try
        {
            // Open the file
            xlApp = new MSExcel.Excel.ApplicationClass();
            xlBook = xlApp.Workbooks.Open(sourceFilename, 0, false, 5, null, null, false, MSExcel.Excel.XlPlatform.xlWindows, null, true, false, 0, true, false, false);
            var xlSheets = xlBook.Worksheets;
            //Get the first Sheet
            xlSheet = (MSExcel.Excel.Worksheet)xlSheets.Item[1];
    
            // Change the file
            MSExcel.Excel.Range priceTypeCell = (MSExcel.Excel.Range)xlSheet.Cells[7, 3];
            //if (priceTypeCell.Value2.ToString() == "Price Push") <= This is probably fine, but just in case...
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
            // Cleanup
            if (xlSheet != null) Marshal.ReleaseComObject(xlSheet);
            if (xlBook != null) Marshal.ReleaseComObject(xlBook);
            if (xlApp != null) xlApp.Quit();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
