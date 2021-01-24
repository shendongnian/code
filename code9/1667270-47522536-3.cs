	[TestMethod]
	public void RangeConversionTest()
	{
		var fileInfo = new FileInfo("c:\\temp\\RangeConversionTest.xlsx");
		if (fileInfo.Exists)
			fileInfo.Delete();
		using (var pck = new ExcelPackage(fileInfo))
		{
			//Some random data
			var wb = pck.Workbook;
			var ws = wb.Worksheets.Add("Sheet1");
			var random = new Random();
			const int rows = 20;
			const int cols = 15;
			for (var row = 0; row < rows; row++)
			{
				for (var c = 0; c < cols; c++)
				{
					if (row == 0 && c == 0)
						ws.Cells[row + 1, c + 1].Value = null;
					else if (row == 0)
						ws.Cells[row + 1, c + 1].Value = $"Column {c}";
					else if (c == 0)
						ws.Cells[row + 1, c + 1].Value = $"Row {row}";
					else
						ws.Cells[row + 1, c + 1].Value = random.Next(5);
				}
			}
			ExcelRange r;
			string s = "B2:N20";
			var srange = ws.Cells[s];
			var startcell = srange.Start;
			var endcell = srange[srange.End.Row - 1, srange.End.Column - 1].Start;
			srange = ws.Cells[s];
			r = srange[startcell.Row, startcell.Column, endcell.Row, endcell.Column];
			r.Sort(new[] {3, r.Columns - 1}, new[] {true, true});
			r[1, 3, r.End.Row, r.End.Column].Style.Numberformat.Format = "0.00";
			pck.Save();
		}
