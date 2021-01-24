	[TestMethod]
	public void SheetReferenceTest()
	{
		//https://stackoverflow.com/questions/47144930
		var file = new FileInfo(@"c:\temp\SheetReferenceTest.xlsx");
		if (file.Exists)
			file.Delete();
		using (var pck = new ExcelPackage(file))
		{
			var group = 1;
			var workbook = pck.Workbook;    
			var group1 = workbook.Worksheets.Add($"group{group}");
			var summarysheet = workbook.Worksheets.Add("summarysheet");
			group1.Cells["A1"].Value = 2;
			group1.Cells["A2"].Value = 3;
			group1.Cells["A3"].Value = 6;
			group1.Cells["A4"].Value = 27;
			group1.Cells["A5"].Formula = "Average(A1:A4)";
			//This shows "=group1!A5" in Excel when the cell is selected
			summarysheet.Cells["A1"].Formula = $"group{group}!A5";
			pck.Save();
		}
	}
