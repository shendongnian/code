    public void readFile(path)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
                    Microsoft.Office.Interop.Excel.Sheets xlsheets = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
                    Microsoft.Office.Interop.Excel.Range xlRange = null;
    
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    workbooks = xlApp.Workbooks;
                    xlWorkbook = workbooks.Open(path);
                    xlsheets = xlWorkbook.Sheets;
                    xlWorksheet = xlsheets[1];
                    xlRange = xlWorksheet.UsedRange;
    
                    //--------------------------------------------------------------------
    
                    xlWorkbook.Close();
                    workbooks.Close();
                    xlApp.Quit();
    
                    Marshal.FinalReleaseComObject(xlRangeColumns);
                    Marshal.FinalReleaseComObject(xlRangeRows);
                    Marshal.FinalReleaseComObject(xlRange);
                    Marshal.FinalReleaseComObject(xlWorksheet);
                    Marshal.FinalReleaseComObject(xlsheets);
                    Marshal.FinalReleaseComObject(xlWorkbook);
                    Marshal.FinalReleaseComObject(workbooks);
                    Marshal.FinalReleaseComObject(xlApp);
    
                    xlRangeColumns = null;
                    xlRangeRows = null;
                    xlRange = null;
                    xlWorksheet = null;
                    xlsheets = null;
                    xlWorkbook = null;
                    workbooks = null;
                    xlApp = null;
                    }
                    catch (Exception e)
                    {
        
                    }
                }
