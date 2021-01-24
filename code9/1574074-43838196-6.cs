    public Worksheet AccessSpecificExcelSheet(Sheets allExcelSheets, string sheetName)
    {
        Worksheet selectedWorksheet = allExcelSheets.get_Item(sheetName);
        selectedWorksheet.Select();
        
        //Select cell A1 when opening
        Range topExcel = selectedWorksheet.get_Range("A1", Type.Missing);
        topExcel.Select();
        
        return selectedWorksheet;
    }
