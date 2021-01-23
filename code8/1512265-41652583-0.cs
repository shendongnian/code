	[TestMethod]
	public void Row_Grouping_Test()
	{
		//http://stackoverflow.com/questions/41636336/grouping-excel-rows-with-epplus
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[]
		{
			new DataColumn("Header", typeof (string)), new DataColumn("Col1", typeof (int)), new DataColumn("Col2", typeof (int)), new DataColumn("Col3", typeof (object))
		});
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			row[0] = $"Header {i}"; row[1] = i; row[2] = i * 10; row[3] = Path.GetRandomFileName(); datatable.Rows.Add(row);
		}
		//Create a test file
		var fi = new FileInfo(@"c:\temp\Row_Grouping_Test.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, false);
			worksheet.Cells["A11"].Value = "TOTAL";
			worksheet.Cells["B11"].Formula = "SUM(B2:B10)";
			worksheet.Cells["C11"].Formula = "SUM(C2:C10)";
			worksheet.Row(11).Style.Font.Bold = true;
			//Row Group 1 (start with 1 since row index is 1-based)
			for (var i = 1; i <= datatable.Rows.Count; i++)
				worksheet.Row(i).OutlineLevel = 1;
			pck.Save();
		}
	}
