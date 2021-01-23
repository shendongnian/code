    string sheetRange = "DataSheet1_A1_D1";
    string[] splitStringArray = sheetRange.Split('_');
    string sheetToGet = splitStringArray[0];
    string firstCell = splitStringArray[1];
    string lastCell = splitStringArray[2];
    // Use the specified sheet
    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheetToGet];
    // Get the full range to work with 
    Range currentRange = xlWorkSheet.get_Range(firstCell + ":" + lastCell, Type.Missing);
    // Note here:
    // You could use "A","B","C"... etc to specify a column
    // However... When the range is returned... The returned range will start on Col "A"
    // so the given values wont match anyway...
    // However all we need to know though is how many columns are involved
     
    int colCount = currentRange.Columns.Count;
    // the variables below are for testing the output
    int curRow = 1;
    int curCol = 1;
    foreach (Range row in currentRange.Rows)
    {
      curCol = 1;
      for (int i = 1; i <= colCount; i++)
      {
        ((Excel.Range)row.Cells[1, i]).Value2 = "Row: " + curRow + " Column: " + curCol;
        curCol++;
      }
      curRow++;
    }
