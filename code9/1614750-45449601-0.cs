    finalWB.SaveAs(excelReportSaveas, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
    app.Workbooks.Close();
