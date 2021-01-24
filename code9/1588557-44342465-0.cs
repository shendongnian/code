     using System.IO;
     namespace Portal.WebApp.Models
     {
         public class ExcelFileBuilder
         {
             public void CreateIfNotExisting(string excelPath)
             {
                 if (!File.Exists(excelPath))
                 {
                     var app = new Microsoft.Office.Interop.Excel.Application();
                     var wb = app.Workbooks.Add();
                     wb.SaveAs(excelPath);
                     wb.Close();
                 }
             }
         }
     }
