          Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string str;
            int rCnt = 0;
            int cCnt = 0;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open("testone.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            Microsoft.Office.Interop.Excel.Range xlFound =range.EntireRow.Find("C2",misValue, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,Excel.XlSearchOrder.xlByColumns,Excel.XlSearchDirection.xlNext,true, misValue, misValue);
            if (!(xlFound == null))
            {
                int ID_Number = xlFound.Column;
                int rownum = xlFound.Row;
                Console.WriteLine(ID_Number);
                Console.WriteLine(rownum);
                Console.Read();
            }
