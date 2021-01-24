    class Program
    {
        static void Main(string[] args)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
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
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad
            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
             Console.ReadLine();
        }
    }
    }
