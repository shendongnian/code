    using Excel = Microsoft.Office.Interop.Excel;
    class Program
    {
        static void Main(string[] args)
        {
           var excelapp = new Excel.Application();
           excelapp.Workbooks.Add();
           string path = "Your Excel Path";            
           Excel.Workbook workbook = excelapp.Workbooks.Open(path);
           Excel.Worksheet workSheet = workbook.Worksheets.get_Item(1);
           Excel.Range source = workSheet.Range["A9:L9"].Insert(Excel.XlInsertShiftDirection.xlShiftDown);
           Excel.Range dest = workSheet.Range["F10"];
           source.Copy(dest);
        }
    }
 
