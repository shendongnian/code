    using Excel = Microsoft.Office.Interop.Excel;
    class Program
    {
        static void Main(string[] args)
        {
            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            // VBA code goes here:
            excelApp.Columns["A:B"].Select
                excelApp.ActiveWorkbook.Worksheets("test").Sort.SortFields.Clear
                excelApp.ActiveWorkbook.Worksheets("test").Sort.SortFields.Add Key:=Range["A:B"], _
                    SortOn:=Excel.XlSortOn.xlSortOnValues, Order:=Excel.XlSortOrder.xlAscending, _
                    DataOption:=Excel.XlSortDataOption.xlSortNormal
                excelApp.ActiveWorkbook.Worksheets("test").Sort.SetRange Range["A:B"]
                excelApp.ActiveWorkbook.Worksheets("test").Sort.Header = Excel.XlYesNoGuess.xlGuess
                excelApp.ActiveWorkbook.Worksheets("test").Sort.MatchCase = False
                excelApp.ActiveWorkbook.Worksheets("test").Sort.Orientation = Excel.Constants.xlTopToBottom
                excelApp.ActiveWorkbook.Worksheets("test").Sort.SortMethod = Excel.XlSortMethod.xlPinYin
                excelApp.ActiveWorkbook.Worksheets("test").Sort.Apply
            excelApp.Visible = true;
        }
    }
