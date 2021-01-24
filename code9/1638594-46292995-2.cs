    Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\acn\Desktop\CopyofFinancialSample.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                int count = 0;
                for (int j = 1; j <= colCount; j++)
                {
                 
                    //add useful things here!   
                    if (j != 1)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            count++;
                        }
                    }
                
                }
                if (count > 0)
                {
                }
                else
                {
                    if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                        Console.WriteLine(xlRange.Cells[i, 1].Value2.ToString() + "\t");
                }
            }
