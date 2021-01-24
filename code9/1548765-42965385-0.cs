    using MSExcel = Microsoft.Office.Interop.Excel;
    
    namespace ProjectReader
    {
        public class ExcelExport
        {
    
            public ExcelExport()
            {
                xlApp = new MSExcel.Application();
                xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            }
    
            public void CreateFile()
            {
                object missingValue = System.Reflection.Missing.Value;
    
                foreach (MSExcel.Worksheet sht in xlWorkBook.Sheets)
                {
                    if (xlWorkBook.Worksheets.Count > 1)
                    {
                        sht.Delete();
                    }
                }
    
                **xlWorkSheet = (MSExcel.Worksheet)xlWorkBook.Sheets[1];**
            }
    
            private MSExcel.Application xlApp;
            private MSExcel.Workbook xlWorkBook;
            private MSExcel.Worksheet xlWorkSheet;
        }
    }
