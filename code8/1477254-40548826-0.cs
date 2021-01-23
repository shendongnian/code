    Public static void ReplaceTextInExcelFile(string filename, string replace, string replacement)
    {
        object m = Type.Missing;
    
        // open excel.
        Application app = new ApplicationClass();
    
        // open the workbook. 
        Workbook wb = app.Workbooks.Open(
            filename,
            m, false, m, m, m, m, m, m, m, m, m, m, m, m);
    
        // get the active worksheet. (Replace this if you need to.) 
        Worksheet ws = (Worksheet)wb.ActiveSheet;
    
        // get the used range. 
        Range r = (Range)ws.UsedRange;
    
        // call the replace method to replace instances. 
        bool success = (bool)r.Replace(
            replace,
            replacement,
            XlLookAt.xlWhole,
            XlSearchOrder.xlByRows,
            true, m, m, m);
    
        // save and close. 
        wb.Save();
        app.Quit();
        app = null;
    }
