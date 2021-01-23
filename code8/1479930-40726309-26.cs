    class Program {
      static void Main(string[] args) {
        Excel.Application excel = new Excel.Application();
        string originalPath = @"H:\ExcelTestFolder\Book1_Test.xls";
        Excel.Workbook workbook = excel.Workbooks.Open(originalPath);
        Excel.Worksheet worksheet = workbook.Worksheets["Sheet1"];
        Excel.Range usedRange = worksheet.UsedRange;
     
        RemoveEmptyTopRowsAndLeftCols(worksheet, usedRange);
        DeleteEmptyRowsCols(worksheet);
      
        string newPath = @"H:\ExcelTestFolder\Book1_Test_Removed.xls";
        workbook.SaveAs(newPath, Excel.XlSaveAsAccessMode.xlNoChange);
        workbook.Close();
        excel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        Console.WriteLine("Finished removing empty rows and columns - Press any key to exit");
        Console.ReadKey();
      }
      private static void DeleteEmptyRowsCols(Excel.Worksheet worksheet) {
        Excel.Range targetCells = worksheet.UsedRange;
        object[,] allValues = (object[,])targetCells.Cells.Value;
        int totalRows = targetCells.Rows.Count;
        int totalCols = targetCells.Columns.Count;
        List<int> emptyRows = GetEmptyRows(allValues, totalRows, totalCols);
        List<int> emptyCols = GetEmptyCols(allValues, totalRows, totalCols);
        // now we have a list of the empty rows and columns we need to delete
        DeleteRows(emptyRows, worksheet);
        DeleteCols(emptyCols, worksheet);
      }
      private static void DeleteRows(List<int> rowsToDelete, Excel.Worksheet worksheet) {
        // the rows are sorted high to low - so index's wont shift
        foreach (int rowIndex in rowsToDelete) {
          worksheet.Rows[rowIndex].Delete();
        }
      }
      private static void DeleteCols(List<int> colsToDelete, Excel.Worksheet worksheet) {
        // the cols are sorted high to low - so index's wont shift
        foreach (int colIndex in colsToDelete) {
          worksheet.Columns[colIndex].Delete();
        }
      }
 
      private static List<int> GetEmptyRows(object[,] allValues, int totalRows, int totalCols) {
        List<int> emptyRows = new List<int>();
        for (int i = 1; i < totalRows; i++) {
          if (IsRowEmpty(allValues, i, totalCols)) {
            emptyRows.Add(i);
          }
        }
        // sort the list from high to low
        return emptyRows.OrderByDescending(x => x).ToList();
      }
      private static List<int> GetEmptyCols(object[,] allValues, int totalRows, int totalCols) {
        List<int> emptyCols = new List<int>();
        for (int i = 1; i < totalCols; i++) {
          if (IsColumnEmpty(allValues, i, totalRows)) {
            emptyCols.Add(i);
          }
        }
        // sort the list from high to low
        return emptyCols.OrderByDescending(x => x).ToList();
      }
      private static bool IsColumnEmpty(object[,] allValues, int colIndex, int totalRows) {
        for (int i = 1; i < totalRows; i++) {
          if (allValues[i, colIndex] != null) {
            return false;
          }
        }
        return true;
      }
      private static bool IsRowEmpty(object[,] allValues, int rowIndex, int totalCols) {
        for (int i = 1; i < totalCols; i++) {
          if (allValues[rowIndex, i] != null) {
            return false;
          }
        }
        return true;
      }
    
      private static void RemoveEmptyTopRowsAndLeftCols(Excel.Worksheet worksheet, Excel.Range usedRange) {
        string addressString = usedRange.Address.ToString();
        int rowsToDelete = GetNumberOfTopRowsToDelete(addressString);
        DeleteTopEmptyRows(worksheet, rowsToDelete);
        int colsToDelete = GetNumberOfLeftColsToDelte(addressString);
        DeleteLeftEmptyColumns(worksheet, colsToDelete);
      }
    
      private static void DeleteTopEmptyRows(Excel.Worksheet worksheet, int startRow) {
        for (int i = 0; i < startRow - 1; i++) {
          worksheet.Rows[1].Delete();
        }
      }
     
      private static void DeleteLeftEmptyColumns(Excel.Worksheet worksheet, int colCount) {
        for (int i = 0; i < colCount - 1; i++) {
          worksheet.Columns[1].Delete();
        }
      }
    
      private static int GetNumberOfTopRowsToDelete(string address) {
        string[] splitArray = address.Split(':');
        string firstIndex = splitArray[0];
        splitArray = firstIndex.Split('$');
        string value = splitArray[2];
        int returnValue = -1;
        if ((int.TryParse(value, out returnValue)) && (returnValue >= 0))
          return returnValue;
        return returnValue;
      }
    
      private static int GetNumberOfLeftColsToDelte(string address) {
        string[] splitArray = address.Split(':');
        string firstindex = splitArray[0];
        splitArray = firstindex.Split('$');
        string value = splitArray[1];
        return ParseColHeaderToIndex(value);
      }
    
      private static int ParseColHeaderToIndex(string colAdress) {
        int[] digits = new int[colAdress.Length];
        for (int i = 0; i < colAdress.Length; ++i) {
          digits[i] = Convert.ToInt32(colAdress[i]) - 64;
        }
        int mul = 1; int res = 0;
        for (int pos = digits.Length - 1; pos >= 0; --pos) {
          res += digits[pos] * mul;
          mul *= 26;
        }
        return res;
      }
    }
