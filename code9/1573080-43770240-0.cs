    public static List<string> ReadExcelDataFile(string fileFullPath)
        {
            Application xlApp = new Application();
            Workbook xlWorkBook = null;
            Worksheet dataSheet = null;
            Range dataRange = null;
            List<string> data = new List<string>();
            object[,] valueArray;
            try
            {
                // Open the excel file
                xlWorkBook = xlApp.Workbooks.Open(fileFullPath, null, true);
                if (xlWorkBook.Worksheets != null
                    && xlWorkBook.Worksheets.Count > 0)
                {
                    // Get the first data sheet
                    dataSheet = xlWorkBook.Worksheets[1];
                    // Get range of data in the worksheet
                    dataRange = dataSheet.UsedRange;
                    // Read all data from data range in the worksheet
                    valueArray = (object[,])dataRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
                    // Here if you sure of the column index then you need not loop and find the column in excel shet. Just directly index to the column and skip first loop
                    for (int colIndex = 0; colIndex < valueArray.GetLength(1); colIndex++)
                    {
                        if (valueArray[0, colIndex] != null
                            && !string.IsNullOrEmpty(valueArray[0, colIndex].ToString())
                            && valueArray[0, colIndex].ToString().Equals("status"))
                        {
                            for (int rowIndex = 1; rowIndex < valueArray.GetLength(0); rowIndex++)
                            {
                                if (valueArray[rowIndex, colIndex] != null
                                    && !string.IsNullOrEmpty(valueArray[rowIndex, colIndex].ToString()))
                                {
                                    // Get data from each column which is not null and is a numeric value
                                    data.Add(valueArray[rowIndex, colIndex].ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Invalid or Empty sheet");
                }
            }
            catch (Exception generalException)
            {
                throw generalException;
            }
            finally
            {
                if (xlWorkBook != null)
                {
                    // Close the workbook after job is done
                    xlWorkBook.Close();
                    xlApp.Quit();
                }
            }
            return data;
        }
