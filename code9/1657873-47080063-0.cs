    // Get used range.
    IRange usedRange = sheet.UsedRange;
    // Setup 2D object array to copy cell values into.
    object[,] values = new object[usedRange.RowCount, usedRange.ColumnCount];
    // Loop through range in row groups.
    for (int row = 0; row < usedRange.RowCount; row++)
    {
        // Loop through each column in a single row.
        for (int col = 0; col < usedRange.ColumnCount; col++)
        {
            // Get current cell.
            IRange cell = usedRange[row, col];
            object cellVal;
            // Special Case: Number formatted as dates/dateTimes/times.
            if (cell.ValueType == SpreadsheetGear.ValueType.Number)
            {
                // Cells formatted as a Date, DateTime or Time
                if (cell.NumberFormatType == NumberFormatType.Date || cell.NumberFormatType == NumberFormatType.DateTime || cell.NumberFormatType == NumberFormatType.Time)
                {
                    DateTime dateTime = workbook.NumberToDateTime((double)cell.Value);
                    Console.WriteLine($"Found a 'date' or 'datetime' or 'time' cell - {cell.Address} - {dateTime.ToString()}");
                    cellVal = dateTime;
                }
                // For any other numeric value, copy as-is.
                else
                {
                    cellVal = cell.Value;
                }
            }
            // For all other ValueTypes (Text / Logical / Empty / Error), copy as-is.
            else
                cellVal = cell.Value;
            // Set object[,] value.
            values[row, col] = cellVal;
        }
    }
