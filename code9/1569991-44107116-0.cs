    // Encode LineFeeds in column headers (row 0)
    IRow rowColHeaders = sheet.GetRow(0);
    foreach (ICell cell in rowColHeaders.Cells)
    {
        string content = cell.StringCellValue;
        if (content.Contains("\n"))
            cell.SetCellValue(content.Replace("\n", "_x000a_"));
    }
