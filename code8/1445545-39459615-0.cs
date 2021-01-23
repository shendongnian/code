	using (var pck = new ExcelPackage(fi))
	{
		var wb = pck.Workbook;
		var ws = wb.Worksheets.Add("Sheet1");
		//Header
		ws.Cells[1, 1].Value = "A";
		ws.Cells[1, 2].Value = "B";
		ws.Cells[1, 3].Value = "C";
		ws.Cells[1, 4].Value = "D";
		var headerrange = ws.Cells[1, 1, 1, 4];
		headerrange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
		headerrange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
		headerrange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
		headerrange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
		headerrange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
		
		ws.View.FreezePanes(1,4);
		ws.PrinterSettings.RepeatRows = new ExcelAddress("$1:$1");
		//Some data > 1 page
		for (var i = 0; i < 1000; i++)
		{
			ws.Cells[2 + i, 1].Value = DateTime.Now.AddDays(i);
			ws.Cells[2 + i, 2].Value = i;
			ws.Cells[2 + i, 3].Value = i*100;
			ws.Cells[2 + i, 4].Value = Path.GetRandomFileName();
		}
		//Save it
		pck.Save();
	}
