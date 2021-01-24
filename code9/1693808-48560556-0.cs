        public void readFile(string path)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
            Microsoft.Office.Interop.Excel.Range xlRange = null;
			
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                workbooks = xlApp.Workbooks;
                xlWorkbook = workbooks.Open(path);
                xlWorksheet = xlWorkbook.Sheets[1];
                xlRange = xlWorksheet.UsedRange;
                //------Here is where I will read the data
            }
            catch (Exception e)
            {
				
            }
            finally
            {
                xlWorkbook?.Close();
                workbooks?.Close();
                xlApp?.Quit();
                Marshal.FinalReleaseComObject(xlRange);
                Marshal.FinalReleaseComObject(xlWorksheet);
                Marshal.FinalReleaseComObject(xlWorkbook);
                Marshal.FinalReleaseComObject(workbooks);
                Marshal.FinalReleaseComObject(xlApp);                
				
				xlRange = null;
                xlWorksheet = null;
                xlWorkbook = null;
                workbooks = null;
                xlApp = null;
            }
        }
