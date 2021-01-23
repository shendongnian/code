       public void ExportFile(Parameter1,parameter2)
         {
        var data ="Fire Query in database using Parameter and Get Data";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment;filename=Report.xlsx");
        Response.AddHeader("Content-Type", "application/vnd.ms-excel");  
        ExcelPackage objExcel = new ExcelPackage();
         ExcelWorksheet reportsheet = objExcel.Workbook.Worksheets.Add("Report");
                        reportsheet.Cells["A1"].LoadFromDataTable(AccessHelper.ToLocationDataTable(data), true);
         objExcel.Save();
         using (MemoryStream MyMemoryStream = new MemoryStream())
          {
         objExcel.SaveAs(MyMemoryStream);
        MyMemoryStream.WriteTo(Response.OutputStream);
         Response.Flush();
         Response.End();
         }
        }
