    var pck = new ExcelPackage(excelFileStream);
	ExcelWorksheet ws = pck.Workbook.Worksheets.First();
	
	DataTable dt = new DataTable(ws.Name);
	int totalCols = ws.Dimension.End.Column;
	int totalRows = ws.Dimension.End.Row;
	int startRow = 3;
	ExcelRange wsRow;
	DataRow dr;
	foreach (var firstRowCell in ws.Cells[2, 1, 2, totalCols])
	{
		dt.Columns.Add(firstRowCell.Text);
	}
	
	for (int rowNum = startRow; rowNum <= totalRows; rowNum++)
	{
		wsRow = ws.Cells[rowNum, 1, rowNum, totalCols];
		dr = dt.NewRow();
		int rowCnt = 0;
		foreach (var cell in wsRow)
		{
			if (rowCnt == 7)
			{
				if (cell.Hyperlink != null)
				{
					dr[cell.Start.Column - 1] = cell.Hyperlink.AbsoluteUri;
				}
			}
			else
			{
				dr[cell.Start.Column - 1] = cell.Text;
			}
	
			rowCnt++;
		}
	
		if (!String.IsNullOrEmpty(dr[7].ToString()))
		{
			dt.Rows.Add(dr);
		}
	}
	
	return dt;
