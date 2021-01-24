    public void Yahfoufi(string excelFile)
    {
        var exapp = new Microsoft.Office.Interop.Excel.Application {Visible = true};
        var wrb = exapp.Workbooks.Open(excelFile);
        var sh = wrb.Sheets["Sheet1"];
        var lastRow = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByRows);
        var lastCol = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByColumns);
        var target = sh.Range[sh.Range["A1"], sh.Cells[lastRow, lastCol]];
        Range deleteRows = GetEmptyRows(exapp, target);
        Range deleteColumns = GetEmptyColumns(exapp, target);
        deleteColumns?.Delete();
        deleteRows?.Delete();
    }
    private static int GetLastIndexOfNonEmptyCell(
        Microsoft.Office.Interop.Excel.Application app,
        Worksheet sheet,
        XlSearchOrder searchOrder)
    {
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
    private static Range GetEmptyRows(
        Microsoft.Office.Interop.Excel.Application app,
        Range target)
    {
        Range result = null;
        foreach (Range r in target.Rows)
        {
            if (app.WorksheetFunction.CountA(r.Cells) >= 1)
                continue;
            result = result == null
                ? r.EntireRow
                : app.Union(result, r.EntireRow);
        }
        return result;
    }
    private static Range GetEmptyColumns(
        Microsoft.Office.Interop.Excel.Application app,
        Range target)
    {
        Range result = null;
        foreach (Range c in target.Columns)
        {
            if (app.WorksheetFunction.CountA(c.Cells) >= 1)
                continue;
            result = result == null
                ? c.EntireColumn
                : app.Union(result, c.EntireColumn);
        }
        return result;
    }
