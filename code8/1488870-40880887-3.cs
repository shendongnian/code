    Application excelApp = new Application();
    excelApp.SheetsInNewWorkbook = 1;
    ////////////////////////////////////////////
    //Add these lines to make it work???
    ////////////////////////////////////////////
    try {
        excelApp.Visible = true;
    }
    catch {} 
    ////////////////////////////////////////////
    Workbook excelWB = excelApp.Workbooks.Open(@"C:\test.xls", Type.Missing, false);
    _Worksheet excelWS = excelWB.Sheets[1];
    Range cellsRange = excelWS.UsedRange;
    long LastCell = cellsRange.Columns.CountLarge + 1;
    long numberOfRows = cellsRange.Rows.CountLarge;
    excelWS.Cells[1, LastCell] = "Tax Formula";
    for (int i = 2; i <= numberOfRows; i++)
    {
        string niceFormula = "=SUM(L" + i + ",M" + i + ")*N" + i;
        excelWS.Cells[i, LastCell].Formula = niceFormula;
    }
    excelWB.Close(true);
    excelApp.Quit();
