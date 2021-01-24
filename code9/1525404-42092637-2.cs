      string filePath = @"C:\YourPathToExcelFile\YourExcelFile.xls";
      Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
      ExcelApp.Visible = true;
      Workbooks wbs = ExcelApp.Workbooks;
      Workbook xlWorkbook = wbs.Open(filePath, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
      Excel._Worksheet MySheet = xlWorkbook.Sheets[1];
      const int aCol = 1;
      const int bCol = 2;
      const int cCol = 3;
      List<int> rowsToDelete = new List<int>();
      int totalRows = MySheet.UsedRange.Rows.Count;
      for (int i = totalRows; i > 0; i--) {
        if ((MySheet.Cells[i, aCol].Value ?? "").ToString() == "" &&
            (MySheet.Cells[i, bCol].Value ?? "").ToString() == "" &&
            (MySheet.Cells[i, cCol].Value ?? "").ToString() == "") {
          rowsToDelete.Add(i);
        }
      }
 
      foreach (int row in rowsToDelete) {
        ((Range)(MySheet.Rows[row])).Delete(XlDirection.xlUp);
      }
      xlWorkbook.Save();
      xlWorkbook.Close();
      ExcelApp.Quit();
      System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
      System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp);
      Console.WriteLine("Fished processing! Press any key to exit");
      Console.ReadKey();
