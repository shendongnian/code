    private HSSFWorkbook createWorkbook()
    {
		HSSFWorkbook workbook = new HSSFWorkbook();
		HSSFSheet sheet1 = (HSSFSheet)workbook.CreateSheet("Sheet 1");
		HSSFCellStyle style1 = (HSSFCellStyle)workbook.CreateCellStyle();
		style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
		style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
		style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
		style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
		HSSFRow row1 = (HSSFRow)sheet1.CreateRow(0);
		HSSFCell cell1 = (HSSFCell)row1.CreateCell(0);
		cell1.SetCellValue("Header 1");
		cell1.CellStyle = style1;
		HSSFCell cell2 = (HSSFCell)row1.CreateCell(1);
		cell2.SetCellValue("Header 2");
		cell2.CellStyle = style1;
		HSSFCell cell3 = (HSSFCell)row1.CreateCell(2);
		cell3.SetCellValue("Header 3");
		cell3.CellStyle = style1;
		HSSFRow row2 = (HSSFRow)sheet1.CreateRow(1);
		row2.CreateCell(0).SetCellValue("Data 1");
		row2.CreateCell(1).SetCellValue("Data 2");
		row2.CreateCell(2).SetCellValue("Data 3");
		return workbook;
    }
	private string ConvertExcelToHTML(HSSFWorkbook workbook)
	{
		ExcelToHtmlConverter excelToHtmlConverter = new ExcelToHtmlConverter();
		// Set output parameter
		excelToHtmlConverter.OutputColumnHeaders = false;
		excelToHtmlConverter.OutputHiddenColumns = false;
		excelToHtmlConverter.OutputHiddenRows = true;
		excelToHtmlConverter.OutputLeadingSpacesAsNonBreaking = false;
		excelToHtmlConverter.OutputRowNumbers = true;
		excelToHtmlConverter.UseDivsToSpan = true;
		// Process the Excel file
		excelToHtmlConverter.ProcessWorkbook(workbook);
		// Return the HTML
		return excelToHtmlConverter.Document.InnerXml;
	}
	private string GetHTML()
	{
		StringBuilder myBuilder = new StringBuilder();
		myBuilder.AppendLine("see attached for the updated list.");
		myBuilder.AppendLine("");
		myBuilder.AppendLine("<table style='border:1px solid black'>");
		myBuilder.AppendLine("<tr><td>Cell Text</td></tr>");
		myBuilder.AppendLine("<tr><td>{excel}</td></tr>");
		myBuilder.AppendLine("</table>");
		return myBuilder.ToString();
	}
