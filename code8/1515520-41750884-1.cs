    using System;
    using System.IO;
    using Excel = Microsoft.Office.Interop.Excel;
    
    class MainClass
    {
        static void Main()
        {
            string strPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            string[] strFiles = Directory.GetFiles(strPath);
            Excel.Application excel = null;
            bool bMakeOnce = true;
            string strReportName = "Report.xlsx";
            int intFirstLine = 10;
            int intLastColumn = 50;
            int lastRow;
            int lastRowReport;
            int intTotalRows;
    
            Excel.Workbook wkbReport = null;
            string strWkbReportPath;
            int n = 0;
    
            excel = new Excel.Application();
            excel.Visible = true;
    
            foreach (string strFile in strFiles)
            {
                if (strFile.Contains(strReportName))
                {
                    Console.WriteLine(strReportName + " is deleted.");
                    File.Delete(strFile);
                }
            }
    
            foreach (string strFile in strFiles)
            {
                if (strFile.Contains(strReportName))
                {
                    continue;
                }
                Console.WriteLine(strFile);
                Excel.Workbook wkb = null;
                Excel.Worksheet sheet = null;
                Excel.Worksheet sheetReport = null;
                Excel.Range rngLastReport = null;
                Excel.Range rngToCopy = null;
    
                wkb = Open(excel, strFile);
                if (bMakeOnce)
                {
                    bMakeOnce = false;
                    strWkbReportPath = wkb.Path + "\\" + strReportName;
                    wkb.SaveAs(strWkbReportPath);
                    wkb.Close();
                    wkbReport = Open(excel, strWkbReportPath);
                }
                else
                {   
                    sheetReport = wkbReport.Worksheets[1];
                    sheet = wkb.Worksheets[1];
    
                    //lastRow = sheet.Cells[1, 3].get_End(Excel.XlDirection.xlUp).Row;
    
                    intTotalRows = sheet.Rows.Count;
                    lastRow = sheet.Cells[intTotalRows, 1].End(Excel.XlDirection.xlUp).Row;
                    lastRowReport = sheetReport.Cells[intTotalRows, 1].End(Excel.XlDirection.xlUp).Row;
    
                    //lastRowReport = sheetReport.Cells[intTotalRows, 1].get_End(Excel.XlDirection.xlUp).Row;
                    //lastRowReport = sheetReport.Cells[intTotalRows, intTotalRows.End[Excel.XlDirection.xlUp]].Row;
                    n++;
    
                    rngToCopy = sheet.Range[sheet.Cells[intFirstLine,1],sheet.Cells[lastRow, intLastColumn]];
                    int size = rngToCopy.Rows.Count;
                    rngLastReport = sheetReport.Range[sheetReport.Cells[lastRowReport+1, 1], sheetReport.Cells[lastRowReport + 1+size, intLastColumn]];
    
                    rngToCopy.Copy(rngLastReport);
                    wkb.Close(false);
                }
            }
            wkbReport.Close(true);
            excel.Quit();
            Console.WriteLine("Finished!");
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
        //public static Excel.Workbook OpenBook(Excel.Application excelInstance, string fileName, bool readOnly = false, bool editable = true, bool updateLinks = true)
        //{
        //    Excel.Workbook book = excelInstance.Workbooks.Open(
        //        fileName, updateLinks, readOnly,
        //        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
        //        Type.Missing, Type.Missing);
        //    return book;
        //}
    }
