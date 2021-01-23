    class Program
    {
      static void Main(string[] args)
      {
        Excel.Application excel = new Excel.Application();
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string originalPath = desktopPath + @"\ExcelRemove\Book1_Test.xls";
        Excel.Workbook workbook = excel.Workbooks.Open(originalPath);
        Excel.Worksheet worksheet = workbook.Worksheets["Sheet1"];
        DeleteEmptyRowsCols(worksheet);
        string newPath = desktopPath + @"\ExcelRemove\Book1_Test_Removed.xls";
        workbook.SaveAs(newPath, Excel.XlSaveAsAccessMode.xlNoChange);
        workbook.Close();
        excel.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        Console.WriteLine("Finished removing empty rows and columns - Press any key to exit");
        Console.ReadKey();
      }
      private static void DeleteEmptyRowsCols(Excel.Worksheet worksheet)
      {
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
  
      private static void DeleteRows(List<int> rowsToDelete, Excel.Worksheet worksheet)
      {
        // the rows are sorted high to low - so index's wont shift
        foreach (int rowIndex in rowsToDelete)
        {
          worksheet.Rows[rowIndex].Delete();
        }
      }
      private static void DeleteCols(List<int> colsToDelete, Excel.Worksheet worksheet)
      {
        // the cols are sorted high to low - so index's wont shift
        foreach (int colIndex in colsToDelete)
        {
          worksheet.Columns[colIndex].Delete();
        }
      }
  
      private static List<int> GetEmptyCols(object[,] allValues, int totalRows, int totalCols)
      {
        List<int> emptyCols = new List<int>();
        for (int i = 1; i < totalCols; i++)
        {
          if (IsColumnEmpty(allValues, i, totalRows))
          {
            emptyCols.Add(i);
          }
        }
        // sort the list from high to low
        return emptyCols.OrderByDescending(x => x).ToList();
      }
    
      private static bool IsColumnEmpty(object[,] allValues, int colIndex, int totalRows)
      {
        for (int i = 1; i < totalRows; i++)
        {
          if (allValues[i, colIndex] != null)
          {
            return false;
          }
        }
        return true;
      }
      private static List<int> GetEmptyRows(object[,] allValues, int totalRows, int totalCols)
      {
        List<int> emptyRows = new List<int>();
        for (int i = 1; i < totalRows; i++)
        {
          if (IsRowEmpty(allValues, i, totalCols))
          {
            emptyRows.Add(i);
          }
        }
        // sort the list from high to low
        return emptyRows.OrderByDescending(x => x).ToList();
      }
      private static bool IsRowEmpty(object[,] allValues, int rowIndex, int totalCols)
      {
        for (int i = 1; i < totalCols; i++)
        {
          if (allValues[rowIndex, i] != null)
          {
            return false;
          }
        }
        return true;
      }
    }
