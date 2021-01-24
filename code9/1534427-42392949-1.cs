    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    
    object misValue = System.Reflection.Missing.Value;
    //string appPath = Path.GetDirectoryName(Application.ExecutablePath);
    string fileName = "" + "YOUR_PATH" + "\\Templates\\myCSV.csv";
    
    string processName = "test";
    xlApp = new Excel.Application();
    xlWorkBook = xlApp.Workbooks.Open(fileName);
    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    
    xlWorkSheet.Shapes.AddChart(misValue, misValue, misValue, misValue, misValue).Select();
    
    //~~> Make it a Line Chart
                xlApp.ActiveChart.ApplyCustomType(Microsoft.Office.Interop.Excel.XlChartType.xlLine);
    
    //~~> Set the data range
    xlApp.ActiveChart.SetSourceData(xlWorkSheet.Range["B1:B30"]);
    string chartName = "TEST CHART", processType="TEST TYPE";
    xlApp.ActiveChart.ChartWizard(misValue, Title: chartName + " (" + processName + ")", CategoryTitle: "Iterations", ValueTitle: processType);
    
    Excel.ChartObjects chartObjects = (Excel.ChartObjects)(xlWorkSheet.ChartObjects(Type.Missing));
    
    foreach (Excel.ChartObject co in chartObjects)
    {
      co.Select();
      Excel.Chart chart = (Excel.Chart)co.Chart;
      chart.Export("C:\\YOUR_PATH" + @"\" + chart.Name + ".png", "PNG", false);
    }
    
    xlWorkBook.Close(true, misValue, misValue);
    xlApp.Quit();
                
    
    xlWorkSheet = null;
    xlWorkBook = null;
    xlApp = null;
    releaseObject(xlWorkBook);
    releaseObject(xlWorkSheet);
    releaseObject(xlApp);
    
    private void releaseObject(object obj)
    {
      try
      {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        obj = null;
      }
      catch (Exception ex)
      {
        obj = null;
        MessageBox.Show(ex.Message);
      }
      finally
      {
        GC.Collect();
      }
    }
