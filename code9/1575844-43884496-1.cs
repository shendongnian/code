    Application excelApp = new Application();
    Workbook excelWorkbook = null;
    string excelFilePath = "C:\\Users\\Desktop\\Sample.xlsx";
    
    try
    {
      //Create a workbook
      excelWorkbook = excelApp.Workbooks.Add(Type.Missing);
      //Make and name a worksheet
      activeWorksheet = excelWorkbook.ActiveSheet;
      //Write in cell B3 of the worksheet
      Range r = activeWorksheet.get_Range("B3", Type.Missing);
      r.Value2 = "This is a sample.";
      //Save the workbook
      excelWorkbook.SaveAs(excelFilePath, Type.Missing, Type.Missing, Type.Missing, false, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing);  
    }
    catch (Exception ex)
    {
      throw ex;
    }
    finally
    {
      if (excelWorkbook != null)
      {
         excelApp.Calculation = XlCalculation.xlCalculationAutomatic;
         excelApp.DisplayAlerts = false;
         excelWorkbook.RefreshAll();
         excelWorkbook.Close(true, excelFilePath);
         excelApp.Quit();
      }
    }
