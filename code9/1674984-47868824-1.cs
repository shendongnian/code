    string FilePath = @"C:\Filename.xlsx";
    string Password = "12345";
    Excel.Application ExcelApp = new Excel.Application();   // Initialize Excel Application
    ExcelApp.DisplayAlerts = false;            
    Excel.Workbook WB = ExcelApp.Workbooks.Open(FilePath);  // Initialize Excel Workbook
    
            
