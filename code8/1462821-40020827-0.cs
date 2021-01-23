    var style = ws.Cells.Rows[0].Style;
    style.Font.IsBold = true;
    style.ForegroundColor = System.Drawing.Color.LightGray;
    style.Pattern = BackgroundType.Solid;
    ws.Cells.Rows[0].ApplyStyle(style, new StyleFlag { FontBold = true, CellShading = true });
