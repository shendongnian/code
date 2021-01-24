    var cell = sheet.GetRow(row).GetCell(column);
                string Res = "";
    if (cell != null)
                {
                    formula.EvaluateInCell(cell);
    
                    switch (cell.CellType)
                    {
                        case NPOI.SS.UserModel.CellType.Numeric:
                            Res = sheet.GetRow(row).GetCell(column).NumericCellValue.ToString();
                            break;
                        case NPOI.SS.UserModel.CellType.String:
                            Res = sheet.GetRow(row).GetCell(column).StringCellValue;
                            break;
                    }
                }
