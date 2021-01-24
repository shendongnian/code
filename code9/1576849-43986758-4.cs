    private static Range GetEntireEmptyRowsOrColumns(
        Microsoft.Office.Interop.Excel.Application app,
        Range target,
        Func<Range, Range> rowsOrColumns,
        Func<Range, Range> entireRowOrColumn)
    {
        Range result = null;
        foreach (Range c in rowsOrColumns(target))
        {
            if (app.WorksheetFunction.CountA(c.Cells) >= 1)
                continue;
            result = result == null
                ? entireRowOrColumn(c)
                : app.Union(result, entireRowOrColumn(c));
        }
        return result;
    }
