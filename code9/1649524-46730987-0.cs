	HSSFWorkbook workbook = new HSSFWorkbook();
	HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("Sheet1");
	HSSFRow row = (HSSFRow)sheet.CreateRow(0);
	HSSFCell cell = (HSSFCell)row.CreateCell(0);
	cell.SetCellValue("Cell1");
	// Create the drawing patriarch (top level container for all shapes including cell comments)
	IDrawing patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();
	// Client anchor defines size and position of the comment in the worksheet
	IComment comment = patriarch.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 2, 1, 4, 4));
	// Set comment author
	comment.Author = "Author";
	// Set text in the comment
	comment.String = new HSSFRichTextString($"{comment.Author}:{Environment.NewLine}A comment");
	// If you want the author displayed in bold on top like in Excel
	// The author will be displayed in the status bar when on mouse over the commented cell
	IFont font = workbook.CreateFont();
	font.Boldweight = (short)FontBoldWeight.Bold;
	comment.String.ApplyFont(0, comment.Author.Length, font);
	// Set comment visible
	comment.Visible = true;
	// Assign comment to a cell
	cell.CellComment = comment;
	using (MemoryStream exportData = new MemoryStream())
	{
		workbook.Write(exportData);
		Response.ContentEncoding = Encoding.UTF8;
		Response.Charset = Encoding.UTF8.EncodingName;
		Response.ContentType = "application/vnd.ms-excel";
		Response.AddHeader("content-disposition", $"attachment; filename=test.xls");
		Response.Clear();
		Response.BinaryWrite(exportData.GetBuffer());
		Response.End();
	}
