    public FileContentResult ExportInventory()
    {
         DataSet dsInventory = Session["Live_Inventory"] as DataSet;
         var filename = "Excel Inventory.xlsx";
         var excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
         byte[] excelContent = ExportExcel(dsInventory);
         return File(excelContent, excelContentType, filename);
    }
    public byte[] ExportExcel(DataSet dsInventory)
    {
         byte[] result = null;
         ExcelWorksheet workSheet = null;
         int counter = 1000000;
         var package = new ExcelPackage();
         for (int tbl = 1; tbl <= counter; tbl++)
         {
              workSheet = package.Workbook.Worksheets.Add(String.Format("Sheet " + tbl));
              workSheet.Cells["A1"].LoadFromDataTable(dsInventory.Tables[tbl], true);                  
         }
         for (int tbl = counter + 1; tbl <= dsInventory.Table.Count; tbl++)
         {
              workSheet = package.Workbook.Worksheets.Add(String.Format("Sheet " + tbl));
              workSheet.Cells["A1"].LoadFromDataTable(dsInventory.Tables[tbl], true);                  
         }
         result = package.GetAsByteArray();//Exception occurs here when table count > 10 
         return result;
    }
