    Microsoft.Office.Interop.Excel.Application Excel = null;
            Microsoft.Office.Interop.Excel._Workbook oWB = null;
            Microsoft.Office.Interop.Excel._Worksheet oSheet = null;
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    return false;
                }
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                xlWorkSheet.Name = "Details";
               
     }
