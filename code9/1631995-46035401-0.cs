    using Excel = Microsoft.Office.Interop.Excel; //namespace
    var filePath = new 
    FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                "\\Test" + "\\" + pathName + "\\" + subFile + "\\" + pathName + ".xlsx");
    Excel.Application xlApp = new Excel.Application();
    xlApp.Visible = true;
    object misValue = System.Reflection.Missing.Value;
    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Test" + "\\" + pathName + "\\" + subFile + "\\" + pathName + ".xlsx";
    if (filePath.Exists) // checks whether file exist or not
    {
          Excel.Workbook wb = xlApp.Workbooks.Open(path,0, false, misValue, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
          Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.Item["Sheet1"];
          for (int i = 0; i < dateTime.Count; i++)
          {
                // check element already there or not 
                if (ws.Cells[i + 1, 1].Value.ToString() != dateTime[dateTime.Count - i - 1])
                {
                      ws.Rows["1"].insert(); // add new row for new data
                      ws.Cells[1, 1] = dateTime[dateTime.Count - i - 1];
                      ws.Cells[1, 2] = firstTeam[dateTime.Count - i - 1];
                      ws.Cells[1, 3] = secondTeam[dateTime.Count - i - 1];
                }
          }
                    wb.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    wb.Close(true, misValue, misValue);
                    xlApp.Quit();
    }
