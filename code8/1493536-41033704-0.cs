    `ExcelPackage excel = new ExcelPackage();
     var userSheet = excel.Workbook.Worksheets.Add("DB_USER");
     userSheet.Cells["A1"].LoadFromCollection(salaryReportlistObj, true);
     using (var memoryStream = new MemoryStream())
     {
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=Dane.xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
     }
`
