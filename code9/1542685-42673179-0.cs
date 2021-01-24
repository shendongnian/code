    var xlApp = new Microsoft.Office.Interop.Excel.Application();
    if (xlApp == null)
    {
        Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");
        return;
    }
    xlApp.Visible = true;
    
    var wb = xlApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
    var ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
