    var allCells = sheet.Cells[1, 1, sheet.Dimension.End.Row, sheet.Dimension.End.Column];
    var cellFont = allCells.Style.Font;
    cellFont.SetFromFont(new Font("Times New Roman", 12));
    cellFont.Bold = true;
    cellFont.Italic = true;
