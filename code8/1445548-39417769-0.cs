    public static string GetCellValue(SharedStringTable sharedStringTable, Cell cell)
    {
        string value = cell.CellValue.InnerText;
        if (cell.DataType != null
            && cell.DataType.Value == CellValues.SharedString)
        {
            return sharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
        }
        else
        {
            return value;
        }
    }
