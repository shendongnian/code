    var excel = new Microsoft.Office.Interop.Excel.Application();
    excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized;
    excel.Visible = true;
    var workbooks = excel.Workbooks;
    var workbook = workbooks.Open(excelFilePath, ReadOnly: false);
    excel.Visible = false;
