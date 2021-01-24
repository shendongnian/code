    public void getIndexes(int num) 
    {
        var wb = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
        var wsEvars = wb.Sheets["Evars"];
        var wsEvents = wb.Sheets["Events"];
    
        Excel.Worksheet sheet = null; // Declared here
    
        if (num == 0) 
        {
            sheet = wsEvars;
            // Rest of code
            ...
