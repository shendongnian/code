    string filepath = string.Empty;
            string reportname = lblreportname.Text;
            filepath = Application.StartupPath + "\\StandardReports\\" + reportname + ".xls";
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            List<string> WorksheetList = new List<string>();
            try
            {
                //Your code
            }
            catch (Exception ex) { MessageBox.Show(string.Format("Error: {0}", ex.Message)); }
            finally
            {
                xlWorkBook.Close(false, filepath, null);
                Marshal.ReleaseComObject(xlWorkBook);
            }
