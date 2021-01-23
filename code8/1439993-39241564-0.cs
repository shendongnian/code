    public void ExportListUsingEPPlus()
           {
               var data = new[]{ 
                  new{ Name="Myname", Email="myna@google.com"},
                  new{ Name="yourname", Email="your@yahoo.com"},
                  new{ Name="saman", Email="saman@yahoo.com"},
               };
     
               ExcelPackage excel = new ExcelPackage();
               var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
               workSheet.Cells[1, 1].LoadFromCollection(data, true);
               using (var memoryStream = new MemoryStream())
               {
                   Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                   Response.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
                   excel.SaveAs(memoryStream);
                   memoryStream.WriteTo(Response.OutputStream);
                   Response.Flush();
                   Response.End();
               }
           }
