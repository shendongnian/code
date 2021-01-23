    //broadly supported
    DateTime dateTime = DateTime.Parse(text);
    double oaValue = dateTime.ToOADate();
    cell.CellValue = new CellValue(oaValue.ToString(CultureInfo.InvariantCulture));
    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
    cell.StyleIndex = Convert.ToUInt32(_numericDateCellFormatIndex); 
    //supported in excel 2010
    DateTime dateTime = DateTime.Parse(text);
    cell.CellValue = new CellValue(dateTime.ToString("s"));
    cell.DataType = new EnumValue<CellValues>(CellValues.Date);
    cell.StyleIndex = Convert.ToUInt32(_sortableDateCellFormatIndex);
