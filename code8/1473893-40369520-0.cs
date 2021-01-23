    string testingExcel = @"C:\TestingExcel.xlsx";
    Application xlApp = new Application();
    Workbook xlWorkbook = xlApp.Workbooks.Open(testingExcel, Type.Missing, true);
    _Worksheet xlWorksheet = (_Worksheet)xlWorkbook.Sheets[1];
    Range xlRange = xlWorksheet.UsedRange;
    foreach (Range c in xlRange.Rows.Cells)
    {
        Console.WriteLine("Address: " + c.Address + " - Value: " + c.Value);
    }
    xlWorkbook.Close();
    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkbook);
    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp);
