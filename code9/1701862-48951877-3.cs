    using System;
    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    
    class StartUp
    {
        static void Main()
        {
            Excel.Application excel = null;
            excel = new Excel.Application();
            excel.Visible = true;        
            string filePath = @"C:\YourOwnPath\TestWB.xlsx";
            Excel.Workbook wkb = null;
            wkb = Open(excel, filePath);
            
            string part1 = "some value";
            string part2 = "some other value";
            string part12 = string.Concat(part1, part2);
            List<string> lookForList = new List<string> { part1, part2, part12 };
            Excel.Range currentFind = null;
            Excel.Range searchedRange = excel.get_Range("A1", "XFD1048576");
            int cnt = 0;
            while (currentFind == null & cnt < lookForList.Count)
            {
                //make sure to specify all the parameters you need in .Find()
                currentFind = searchedRange.Find(lookForList[cnt]);
                cnt++;
            }
            if (currentFind!=null)
            {
                Console.WriteLine("Found:");
                Console.WriteLine(currentFind.Column);
                Console.WriteLine(currentFind.Row);
            }        
            wkb.Close(true);
            excel.Quit();
        }
    
        public static Excel.Workbook Open(Excel.Application excelInstance, 
                                string fileName, bool readOnly = false, bool editable = true, 
                                bool updateLinks = true)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }
    }
