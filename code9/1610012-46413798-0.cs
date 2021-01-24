    shp.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Size =  8;
    shp.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Name = "Arial (Body)";
    shp.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Bold = MsoTriState.msoTrue;
    int oleColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
    shp.Table.Cell(row, col).Shape.TextFrame.TextRange.Font.Color.RGB = oleColor;
