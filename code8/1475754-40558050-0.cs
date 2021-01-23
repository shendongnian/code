    public static string GetFormattedCellValue(ICell cell)
    {
        if (cell == null || cell.CellType == CellType.Blank || cell.CellType == CellType.Unknown)
        {
            return string.Empty;
        }
        else if (cell.CellType == CellType.Numeric && NPOI.SS.UserModel.DateUtil.IsCellDateFormatted(cell))
        {
            DateTime date = cell.DateCellValue;
            ICellStyle style = cell.CellStyle;
            // Excel uses lowercase 'm' to mean month, while .Net uses uppercase.
            string format = style.GetDataFormatString().Replace('m', 'M');
            return date.ToString(format);
        }
        else if (cell.CellType == CellType.Numeric)
        {
            return cell.NumericCellValue.ToString();
        }
        else if (cell.CellType == CellType.Boolean)
        {
            return cell.BooleanCellValue ? "TRUE" : "FALSE";
        }
        else if (cell.CellType == CellType.Formula)
        {
            IFormulaEvaluator eval = new XSSFFormulaEvaluator(cell.Row.Sheet.Workbook);
            ICell val = eval.EvaluateInCell(cell);
            return GetFormattedCellValue(val);
            // If you don't want to evaluate the formula, use this instead:
            //return cell.CellFormula;
        }
        else if (cell.CellType == CellType.Error)
        {
            return NPOI.SS.UserModel.FormulaError.ForInt(cell.ErrorCellValue).String;
        }
        else
        {
            return cell.StringCellValue;
        }
    }
