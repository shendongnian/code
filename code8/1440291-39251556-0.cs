    using Excel = Microsoft.Office.Interop.Excel;
    ...
    string excelFile = @"C:\Excel\file\path\fileName.xlsx";
    Excel.Application xl = new Excel.Application();
    xl.Visible = true;
    Excel.Workbook wb = xl.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
    ...
    //Create sheet, insert your data and so on
    ...
    xl.DisplayAlerts = false;
    wb.SaveAs(excelFile, Excel.XlFileFormat.xlWorkbookDefault);
    wb.Close(true);
    xl.Quit();
