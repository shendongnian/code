    Using Excel = Microsoft.Office.Intertop.Excel 
    
    Excel.Application xlApp;
    Excel.Workbooks xlBooks;
    Excel.Workbook xlBook;
    Excel.Worksheet xlSheet;
    
    xlApp = new Excel.Application();
    xlBooks = xlApp.Workbooks;
    xlBook = xlBooks.Add("");
    xlSheet = xlBook.ActiveSheet;
                
    xlSheet.Cells[row,col].Font.Bold = true
