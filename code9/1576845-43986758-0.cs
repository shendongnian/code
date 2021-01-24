    public void Yahfoufi(string excelFile)
    {
        var exapp = new Microsoft.Office.Interop.Excel.Application { Visible = true };
        var wrb = exapp.Workbooks.Open(excelFile);
        var sh = wrb.Sheets["Sheet1"];
        var lastRow = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByRows);
        var lastCol = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByColumns);
        var target = sh.Range[sh.Range["A1"], sh.Cells[lastRow, lastCol]];
        Range deleteMe = null;
        foreach (var r in target.Rows)
        {
            if (exapp.WorksheetFunction.CountA(r.Cells) >= 1)
                continue;
            deleteMe = deleteMe == null 
                ? r.EntireRow 
                : exapp.Union(deleteMe, r.EntireRow);
        }
        deleteMe?.Delete();
    }
    private int GetLastIndexOfNonEmptyCell(
        Microsoft.Office.Interop.Excel.Application app, 
        Worksheet sheet, 
        XlSearchOrder searchOrder)
    {
        double numberOfNonEmptyCells = app.WorksheetFunction.CountA(sheet.Cells);
        if (Math.Abs(numberOfNonEmptyCells) < 1)
            return 1;
        Range rng = sheet.Cells.Find(
            What: "*",
            After: sheet.Range["A1"],
            LookIn: XlFindLookIn.xlFormulas,
            LookAt: XlLookAt.xlPart,
            SearchOrder: searchOrder,
            SearchDirection: XlSearchDirection.xlPrevious,
            MatchCase: false);
        if (rng == null)
            return 1;
        return searchOrder == XlSearchOrder.xlByRows
            ? rng.Row
            : rng.Column;
    }
