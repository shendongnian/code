     public static string GetFormattedCellValue(this ICell cell, IFormulaEvaluator eval = null)
        {
            // https://github.com/tonyqus/npoi/blob/master/main/SS/UserModel/BuiltinFormats.cs
            //*The first user-defined format starts at 164.
            //  var dataformatNumber = cell.CellStyle.DataFormat;
            //var formatstring = cell.CellStyle.GetDataFormatString();
            //e.g. m/d/yyyy\ h:mm:ss\ \ AM/PM\ #164
            //e.g m/d/yyyy\ hh:mm  #165
            if (cell != null)
            {
                switch (cell.CellType)
                {
                    case CellType.String:
                        return cell.StringCellValue;
                    case CellType.Numeric:
                        if (DateUtil.IsCellDateFormatted(cell))
                        {
                            DateTime date = cell.DateCellValue;
                            ICellStyle style = cell.CellStyle;
                            // Excel uses lowercase m for month whereas .Net uses uppercase
                            string format = style.GetDataFormatString().Replace('m', 'M');
                            return date.ToString(format);
                        }
                        else if(cell.CellStyle.DataFormat>=164 && DateUtil.IsValidExcelDate(cell.NumericCellValue) && cell.DateCellValue != null)
                        {
                            return cell.DateCellValue.ToString();
                        }
                        else
                        {
                            return cell.NumericCellValue.ToString();
                        }
                    case CellType.Boolean:
                        return cell.BooleanCellValue ? "TRUE" : "FALSE";
                    case CellType.Formula:
                        if (eval != null)
                            return GetFormattedCellValue(eval.EvaluateInCell(cell));
                        else
                            return cell.CellFormula;
                    case CellType.Error:
                        return FormulaError.ForInt(cell.ErrorCellValue).String;
                }
            }
            // null or blank cell, or unknown cell type
            return string.Empty;
        }
