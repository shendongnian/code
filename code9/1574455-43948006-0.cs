    public static class NpoiExtensions
    {
        public static bool IsCellNullOrEmpty(this ISheet sheet, int rowIndex, int cellIndex)
        {
            if (sheet != null)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row != null)
                {
                    ICell cell = row.GetCell(cellIndex);
                    return cell.IsNullOrEmpty();
                }
            }
            return true;
        }
        public static bool IsNullOrEmpty(this ICell cell)
        {
            if (cell != null)
            {
                // Uncomment the following lines if you consider a cell 
                // with no value but filled with color to be non-empty.
                //if (cell.CellStyle != null && cell.CellStyle.FillBackgroundColorColor != null)
                //    return false;
                switch (cell.CellType)
                {
                    case CellType.String:
                        return string.IsNullOrWhiteSpace(cell.StringCellValue);
                    case CellType.Boolean:
                    case CellType.Numeric:
                    case CellType.Formula:
                    case CellType.Error:
                        return false;
                }
            }
            // null, blank or unknown
            return true;
        }
    }
