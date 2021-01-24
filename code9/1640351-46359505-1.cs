	int rowCount = 1;
	int chunkSize = 50000;
	using (ExcelPackage objExcelPackage = new ExcelPackage()) 
	{ 
		ExcelWorksheet objWorksheet = objExcelPackage.Workbook.Worksheets.Add("Conversion Data"); 
		//objWorksheet.Cells["A1"].LoadFromDataTable(FinalResult, true);
		foreach (var smallerTable in FinalResult.AsEnumerable().ToChunks(chunkSize))
		{
			objWorksheet.Cells["A" + rowCount].LoadFromDataTable(smallerTable, true);
			rowCount += chunkSize;
		}
