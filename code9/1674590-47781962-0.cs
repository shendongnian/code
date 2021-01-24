                    using (var range = ws.Cells[1, 1, 1, 11])  //format: ws.Cells[int FromRow, int FromCol, int ToRow, int ToCol]
                {
                    range.Style.Font.Bold = true;
                    range.Style.ShrinkToFit = false;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.AutoFilter = true;
                }
