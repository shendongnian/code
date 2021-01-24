            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\nagendra.k.kumar\Desktop\Talent Review - Nagendra Kumar.xlsx");
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = lWorksheet.UsedRange;
            MessageBox.Show(xlRange.Rows.Count.ToString());
