    Application xlApp = new Application();
    Workbook xlWorkBook = null;
    Worksheet dataSheet = null;
    Range dataRange = null;
    List<string> columnNames = new List<string>();
    object[,] valueArray;
    
    try
    {
        // Open the excel file
        xlWorkBook = xlApp.Workbooks.Open(fileFullPath, 0, true);
    
        if (xlWorkBook.Worksheets != null
            && xlWorkBook.Worksheets.Count > 0)
        {
            // Get the first data sheet
            dataSheet = xlWorkBook.Worksheets[1];
        
            // Get range of data in the worksheet
            dataRange = dataSheet.UsedRange;
        
            // Read all data from data range in the worksheet
            valueArray = (object[,])dataRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
        
            if (xlWorkBook != null)
            {
                // Close the workbook after job is done
                xlWorkBook.Close();
                xlApp.Quit();
            }
        
            for (int colIndex = 0; colIndex < valueArray.GetLength(1); colIndex++)
            {
                if (valueArray[0, colIndex] != null
                    && !string.IsNullOrEmpty(valueArray[0, colIndex].ToString()))
                {
                    // Get name of all columns in the first sheet
                    columnNames.Add(valueArray[0, colIndex].ToString());
                }
            }
        }
        // Now you have column names or to say first row values in this:
        // columnNames - list of strings
    }
    catch (System.Exception generalException)
    {
        if (xlWorkBook != null)
        {
            // Close the workbook after job is done
            xlWorkBook.Close();
            xlApp.Quit();
        }
    }
