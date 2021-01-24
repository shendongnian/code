    var baseStyle = workBook.CreateCellStyle();
    ...
    var priceStyle = workBook.CreateCellStyle();
    priceStyle.CloneStyleFrom(numberStyle);
    priceStyle.DataFormat = workBook.CreateDataFormat().GetFormat("€ #,##0.00");
    private static void SetCellValuePrice(IRow row, ICellStyle cellStyle, int colIndex, decimal value)
    {
        var xlCell = row.CreateCell(colIndex);
        
        xlCell.SetCellValue(Convert.ToDouble(value));
        
        xlCell.CellStyle = cellStyle;
    }
