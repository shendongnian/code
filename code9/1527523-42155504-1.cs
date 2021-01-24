    const string magicWord = "HelloUser";
    
    Excel.Application app = new Excel.Application();
    Excel.Workbook workbook = app.Workbooks.Open(@"myWorkbook.xlsx");
    Excel.Worksheet worksheet = workbook.Sheets[1]; //Excel has no zero based index!!!
    
    int magicWordRowIndex = Int32.MaxValue;
    
     //Here we find your magic word. But we can't delete the rows here, so just save the index
     for (int row = 1; row <= worksheet.Rows.Count; row++)
     {
        for (int column = 1; column <= worksheet.Columns.Count; column++)
        {
           if (worksheet.Rows[row][column] == magicWord)
           {
               magicWordRowIndex = row;
               break;
           }
         }
      }
    
      //Now we run reversed, because else our magicWordRowIndex become invalid if we delete rows
      for (int row = worksheet.Rows.Count; row >= magicWordRowIndex; row--)
      {
         ((Excel.Range) worksheet.Rows[row, Missing.Value]).Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
      }
