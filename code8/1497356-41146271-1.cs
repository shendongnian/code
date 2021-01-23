	[TestMethod]
	public void TestExcellGeneration_HorizontalLoadFromCollection()
	{            
		var excelFileBytes = (new ActionFlagMappingExcelGenerator()).TestExcellGeneration_HorizontalLoadFromCollection();
		OpenExcelFromTempFile(excelFileBytes);
	}
	private void OpenExcelFromTempFile(byte[] data)
	{
		string tempPath = System.IO.Path.GetTempFileName();
		System.IO.File.WriteAllBytes(tempPath, data);
		Application excelApplication = new Application();
		_Workbook excelWorkbook;
		excelWorkbook = excelApplication.Workbooks.Open(tempPath);
		excelApplication.Visible = true; 
	}
