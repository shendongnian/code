    static string GetCellValueFromPossiblyMergedCell(ExcelWorksheet wks, int row, int col)
        {
            var cell = wks.Cells[row, col];
            if (cell.Merge)                                              //(1.)
            {
                var mergedId = wks.MergedCells[row, col];                //(2.)
                return wks.Cells[mergedId].First().Value.ToString();     //(3.)
            }
            else
            {
                return cell.Value.ToString();
            }
        }
