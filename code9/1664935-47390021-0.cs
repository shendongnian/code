    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    class Startup
    {
        static void Main()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wkbReport = Open(excelApp, @"C:\Users\v.doynov\Desktop\Testing.xlsx");
            Excel.Worksheet ws = wkbReport.Worksheets[1];
            Console.WriteLine(ws._CodeName);
            ws.Name = "ABC";
            Console.WriteLine("END");
            excelApp.Visible = true;        
        }
        
        public static Excel.Workbook Open(Excel.Application excelInstance, string fileName, bool readOnly = false, bool editable = true, bool updateLinks = true)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }
    }
