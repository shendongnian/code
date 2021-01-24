    public void DataToExcel(DataTable dataToConvert, HttpResponse response)
    {
    	FileInfo myFile = new FileInfo("~/MyProject/Inventory.xlsx");
    	using (ExcelPackage package = new ExcelPackage(myFile))
    	{
    		ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
    
    		worksheet.Cells["A1"].LoadFromDataTable(dataToConvert, true, OfficeOpenXml.Table.TableStyles.Light1);
    
    		package.Save();
    
    
    		response.Clear();
    		response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
    		response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", "Inventory.xlsx"));
    		response.WriteFile("~/MyProject/Inventory.xlsx");
    		response.Flush();
    		response.End();
    
    	}
    
    }
