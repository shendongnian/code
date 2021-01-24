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
			var random = new Random();
			const int rows = 10;
			const int cols = 15;
			for (var r = 0; r < rows; r++)
				for (var c = 0; c < cols; c++)
					group1.Cells[r + 1, c + 1].Value = random.Next(100);
			//This works fine and auto increments the formala to B1:B10, C1:C10, etc.
			group1.Cells[rows + 1, 1, rows + 1, cols].Formula = $"AVERAGE(A1:A{rows})";
			//This does not, it just does group1!A1:A10 for all cells.
			summarysheet.Cells[rows + 1, 1, rows + 1, cols].Formula = $"AVERAGE(group1!A1:A{rows})";
			pck.Save();
		}
	}
