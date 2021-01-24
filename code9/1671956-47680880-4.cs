    public string GetMergedRange(ExcelWorksheet worksheet, string cellAddress)
    {
        ExcelWorksheet.MergeCellsCollection mergedCells = worksheet.MergedCells;
        foreach (var merged in mergedCells)
        {
            ExcelRange range = worksheet.Cells[merged];
            ExcelCellAddress cell = new ExcelCellAddress(cellAddress);
            if (range.Start.Row<=cell.Row && range.Start.Column <= cell.Column)
            {
                if (range.End.Row >= cell.Row && range.End.Column >= cell.Column)
                {
                    return merged.ToString();
                }
            }
        }
        return "";
    }
