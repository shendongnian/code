     using System;
     using Excel = Microsoft.Office.Interop.Excel;
     public partial class WebForm1 : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {     
             int i = 3, max = 5, index = 1;
             string filePath = @"C:\Users\anandra\Desktop\Book1.xlsx";
             Excel.Application excelApp = new Excel.Application();
             Excel.Workbook workBook = excelApp.Workbooks.Open(filePath);
             for (i = 1; i <= max; i++)
             {
               //Adding an extra check here to skip your error
                 if (i != index + 1 && workBook.Sheets.Count>i )
                 {
                     Excel.Worksheet worksheets = (Excel.Worksheet)workBook.Sheets[i];
                     excelApp.DisplayAlerts = false;
                     worksheets.Delete();
                     excelApp.DisplayAlerts = true;
                     //Decreasing the value of index and i as after deleting the sheet the index will start agarin from 1.
                     i--;
                     index--;
                 }
             }
         }
     }
