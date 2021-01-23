    enum RowOrCol { Row, Column };
    static void Main(string[] args)
    {
      Excel.Application excel = new Excel.Application();
      string originalPath = @"H:\ExcelTestFolder\Book1_Test.xls";
      Excel.Workbook workbook = excel.Workbooks.Open(originalPath);
      Excel.Worksheet worksheet = workbook.Worksheets["Sheet1"];
      Excel.Range usedRange = worksheet.UsedRange;
      // Start test for looping thru each excel worksheet
      Stopwatch sw = new Stopwatch();
      Console.WriteLine("Start stopwatch to loop thru WORKSHEET...");
      sw.Start();
      ConventionalRemoveEmptyRowsCols(worksheet);
      sw.Stop();
      Console.WriteLine("It took a total of: " + sw.Elapsed.Milliseconds + " Miliseconds to remove empty rows and columns...");
      string newPath = @"H:\ExcelTestFolder\Book1_Test_RemovedLoopThruWorksheet.xls";
      workbook.SaveAs(newPath, Excel.XlSaveAsAccessMode.xlNoChange);
      workbook.Close();
      Console.WriteLine("");
      // Start test for looping thru object array
      workbook = excel.Workbooks.Open(originalPath);
      worksheet = workbook.Worksheets["Sheet1"];
      usedRange = worksheet.UsedRange;
      Console.WriteLine("Start stopwatch to loop thru object array...");
      sw = new Stopwatch();
      sw.Start();
      DeleteEmptyRowsCols(worksheet);
      sw.Stop();
      // display results from second test
      Console.WriteLine("It took a total of: " + sw.Elapsed.Milliseconds + " Miliseconds to remove empty rows and columns...");
      string newPath2 = @"H:\ExcelTestFolder\Book1_Test_RemovedLoopThruArray.xls";
      workbook.SaveAs(newPath2, Excel.XlSaveAsAccessMode.xlNoChange);
      workbook.Close();
      excel.Quit();
      System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
      System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
      Console.WriteLine("");
      Console.WriteLine("Finished testing methods - Press any key to exit");
      Console.ReadKey();
    }
