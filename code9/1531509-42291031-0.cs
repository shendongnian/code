    Response.Clear();
    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    Response.AddHeader("content-disposition", "attachment;filename=" +   HttpUtility.UrlEncode("Logs.xlsx", System.Text.Encoding.UTF8));
    using (ExcelPackage pck = new ExcelPackage())
    {
    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Logs");
    ws.Cells["A1"].LoadFromDataTable(dt, true);    
     //Here you can add your Label value to whatever cells you want..for example- A1 or something
                  
    var ms = new System.IO.MemoryStream();
    pck.SaveAs(ms);
    ms.WriteTo(Response.OutputStream);                          
    }
