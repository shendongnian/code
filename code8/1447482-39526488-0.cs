     int Tocolumn = ws.Dimension.End.Column;
     
      foreach (ExcelRangeBase cell in ws.Cells[2, 1, ToRow, 2])
        {
            if (string.IsNullOrEmpty(cell.Text)) continue;
            var text = cell.Text;
            if (text.Equals("0"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#7fcbfe");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("1"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#90ee90");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("2"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#ffee75");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("3"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#fdb957");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("4"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#FF9985");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("5"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#33CCCC");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("6"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#66CCFF");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
            else if (text.Equals("7"))
            {
                Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#FFFF99");
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cell.Start.Row, cell.Start.Column - 1, cell.Start.Row, cell.Start.Column].Style.Fill.BackgroundColor.SetColor(colFromHex);
            }
        }
