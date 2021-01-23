    Excel.Range hideRange = null;
    Excel.Application xl = Globals.ThisAddIn.Application;
    foreach (Excel.Range row in activeWorksheet.UsedRange.Rows)
    {
        if (oApp.WorksheetFunction.CountIf(row, "*" + searchInput + "*") > 0)
            hideRange = hideRange == null ? row : xl.Union(hideRange, row);
    }
    hideRange.EntireRow.Hidden = true;
