	using (var pck = new ExcelPackage(fileInfo))
	{
		var workbook = pck.Workbook;
		var worksheet = workbook.Worksheets.Add("Sheet1");
		worksheet.Cells["A1"].Value = "Test";
		worksheet.Cells["B1"].Value = "Test";
		worksheet.Cells["C1"].Value = "Test";
		worksheet.Cells["D1"].Value = "Test";
		worksheet.Cells["A2"].Value = "Test";
		worksheet.Cells["B2"].Value = "Test";
		worksheet.Cells["C2"].Value = "Test";
		worksheet.Cells["D2"].Value = "Test";
		worksheet.Cells["E2"].Value = "Test";
		worksheet.Cells["A3"].Value = "Test";
		var lastRowCell1 = worksheet.Cells.Last(c => c.Start.Row == 1);
		Console.WriteLine(lastRowCell1.Address); //Prints "D1"
		var lastRowCell2 = worksheet.Cells.Last(c => c.Start.Row == 2);
		Console.WriteLine(lastRowCell2.Address); //Prints "E2"
		var lastColCell1 = worksheet.Cells.Last(c => c.Start.Column == 1);
		Console.WriteLine(lastColCell1.Address); //Prints "A3"
		var lastColCell2 = worksheet.Cells.Last(c => c.Start.Column == 2);
		Console.WriteLine(lastColCell2.Address); //Prints "B2"
	}
