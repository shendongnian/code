    for (int row = 1; row <= objTable.Rows.Count; row++)
    {
        for (int col = 1; col <= objTable.Columns.Count; col++)
        {
            objTable.Cell(row, col).Borders[PPT.PpBorderType.ppBorderLeft].Weight = 0.5f;
            objTable.Cell(row, col).Borders[PPT.PpBorderType.ppBorderRight].Weight = 0.5f;
            objTable.Cell(row, col).Borders[PPT.PpBorderType.ppBorderTop].Weight = 0.5f;
            objTable.Cell(row, col).Borders[PPT.PpBorderType.ppBorderBottom].Weight = 0.5f;
        }
    }
