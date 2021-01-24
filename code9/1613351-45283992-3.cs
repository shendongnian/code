    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xl = new Excel.Application();;
    Excel.Workbook wb = xl.Workbooks.Open("WorkBookfullPath", 0, true);
    foreach (Excel.Worksheet ws in wb.Worksheets) {
            {
                 string wsName = ws.Name;  
            }
