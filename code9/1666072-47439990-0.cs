    using System;
    using Excel = Microsoft.Office.Interop.Excel;    
    class LooperMain
    {
        static void Main()
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook wkb = Open(excel, @"C:\testa.xlsx");
    
            for (int i = wkb.Worksheets.Count; i > 0; i--)
            {
                Excel.Worksheet sheet = wkb.Worksheets[i];
    
                Console.WriteLine(i);
                Console.WriteLine(sheet.Name);
                if (sheet.Name == "something")
                {
                    sheet.Delete();
                }
            }
        }
    
        public static Excel.Workbook Open(Excel.Application excelInstance, 
                string fileName, 
                bool readOnly = false, 
                bool editable = true, 
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
