    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    object misValue = System.Reflection.Missing.Value;
    xlApp.Workbooks.OpenText
        (
        @"C:\newPath\OveralFile.txt",
        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
        1,
        Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited,
        Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierDoubleQuote,
        true,
        true,
        false,
        false,
        false,
        false,
        Type.Missing,
        misValue,
        Type.Missing,
        ".",
        ","
    );
    xlApp.Workbooks[1].SaveAs(@"C:\newPath\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, 
                             misValue, misValue, misValue, misValue, 
                             Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, 
                             misValue, misValue);
    xlApp.Workbooks[1].Close();
    xlApp.Quit();
    Marshal.ReleaseComObject(xlApp.Workbooks);
    Marshal.ReleaseComObject(xlApp);
