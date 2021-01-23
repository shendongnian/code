    //import the references needed. Checkout the article
    
    namespace Sandbox
    {
        public class Read_From_Excel
        {
            public static void getExcelFile()
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\E56626\Desktop\Teddy\VS2012\Sandbox\sandbox_test - Copy - Copy.xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
    
                int rowCount = xlRange.Rows.Count;
                //IMPORTANT SECTION
                var dictionary = new Dictionary<string, List<string>>();
                //iterate over the rows and columns as it appears in the file
                //excel is not zero based!!
                for (int i = 1; i <= rowCount; i++)
                {
                    //it would be nice if we add some null checking to this variables. Check the article again
                    var col1 = xlRange.Cells[i, 1].Value2.ToString();
                    var col2 = xlRange.Cells[i, 2].Value2.ToString();
    
                    if (dictionary.ContainsKey(col1))
                    {
                        var existingList = dictionary[col1];
                        existingList.Add(col2);
                    } 
                    else{
                        var newList = new List<string>();
                        newList.Add(col2);
                        dictionary.Add(col1, newList);
                    }
                    
                }
                //Do whatever you'd like with the dictionary
                //END OF IMPORTANT SECTION
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
        }
    }
    }   
