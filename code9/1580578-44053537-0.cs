	static void Main(string[] args)
	{
		string excelFilePath = "Test1.xlsx";
		string text = "02-25-1999";
		string sheetName = "Sheet1";
		using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(excelFilePath, true))
		{			   
			var stylesheet = spreadsheetDoc.WorkbookPart.WorkbookStylesPart.Stylesheet;
			var numberingFormats = stylesheet.NumberingFormats;
			   
			const string dateFormatCode = "dd/mm/yyyy";
			var dateFormat =
				numberingFormats.OfType<NumberingFormat>()
					.FirstOrDefault(format => format.FormatCode == dateFormatCode);
			if (dateFormat == null)
			{
				dateFormat = new NumberingFormat
				{
					NumberFormatId = UInt32Value.FromUInt32(164),
					// Built-in number formats are numbered 0 - 163. Custom formats must start at 164.
					FormatCode = StringValue.FromString(dateFormatCode)
				};
				numberingFormats.AppendChild(dateFormat);
				numberingFormats.Count = Convert.ToUInt32(numberingFormats.Count());
				stylesheet.Save();
			}
			// get the (1-based) index 
			var dateStyleIndex = numberingFormats.ToList().IndexOf(dateFormat) + 1;
			var worksheetPart = GetWorksheetPartByName(spreadsheetDoc, "Sheet1");
			
			Row row1 = worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>().FirstOrDefault();
			Cell cell = row1.Elements<Cell>().FirstOrDefault();
			DateTime dateTime = DateTime.Parse(text);
			double oaValue = dateTime.ToOADate();
			cell.CellValue = new CellValue(oaValue.ToString(CultureInfo.InvariantCulture));
			cell.StyleIndex = Convert.ToUInt32(dateStyleIndex);
			worksheetPart.Worksheet.Save();
			spreadsheetDoc.WorkbookPart.WorkbookStylesPart.Stylesheet.Save();
		}
		Console.ReadKey();
	}
