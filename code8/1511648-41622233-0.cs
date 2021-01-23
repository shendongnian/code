        if (IsNumeric(contents[contentsIndex]))
    {
        cell.DataType = new EnumValue<CellValues>(CellValues.Number);
        cell.CellValue = new CellValue(contents[contentsIndex]);
     }
     else
     {
         cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
         cell.CellValue = new CellValue(index.ToString());
     }
