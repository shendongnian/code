    private static void RemoveEmptyRowsCols3(Excel.Worksheet worksheet)
    {
      //Excel.Range usedRange = worksheet.UsedRange;     // <- using this variable makes the while loop much faster 
      int rowIndex = 1;
      // delete empty rows
      //while (rowIndex <= usedRange.Rows.Count)     // <- changing this one line makes a huge difference - not grabbibg the UsedRange with each iteration...
      while (rowIndex <= worksheet.UsedRange.Rows.Count)
      {
        if (excel.WorksheetFunction.CountA(worksheet.Cells[rowIndex, 1].EntireRow) == 0)
        {
          worksheet.Cells[rowIndex, 1].EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
        }
        else
        {
          rowIndex++;
        }
      }
      // delete empty columns
      int colIndex = 1;
      // while (colIndex <= usedRange.Columns.Count) // <- change here also
    
      while (colIndex <= worksheet.UsedRange.Columns.Count)
      {
        if (excel.WorksheetFunction.CountA(worksheet.Cells[1, colIndex].EntireColumn) == 0)
        {
          worksheet.Cells[1, colIndex].EntireColumn.Delete(Excel.XlDeleteShiftDirection.xlShiftToLeft);
        }
        else
        {
          colIndex++;
        }
      }
    }
