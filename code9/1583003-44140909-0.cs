	private SpreadsheetDocument _spreadSheet;
	private WorksheetPart _worksheetPart;
	..
	..
	private void UpdateCell(Cell cell, DataTypes type, string text)
	{
		if (type == DataTypes.String)
		{
			cell.DataType = CellValues.SharedString;
			if (!_spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any())
			{
				_spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
			}
			var sharedStringTablePart = _spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
			if (sharedStringTablePart.SharedStringTable == null)
			{
				sharedStringTablePart.SharedStringTable = new SharedStringTable();
			}
			//Iterate through shared string table to check if the value is already present.
			foreach (SharedStringItem ssItem in sharedStringTablePart.SharedStringTable.Elements<SharedStringItem>())
			{
				if (ssItem.InnerText == text)
				{
					cell.CellValue = new CellValue(ssItem.ElementsBefore().Count().ToString());
					return;
				}
			}
			// The text does not exist in the part. Create the SharedStringItem.
			var item = sharedStringTablePart.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
			cell.CellValue = new CellValue(item.ElementsBefore().Count().ToString());
		}
		else if (type == DataTypes.Number)
		{
			cell.CellValue = new CellValue(text);
			cell.DataType = CellValues.Number;
		}
		else if (type == DataTypes.DateTime)
		{
			cell.DataType = CellValues.Number;
			cell.StyleIndex = Convert.ToUInt32(_dateStyleIndex);
			DateTime dateTime = DateTime.Parse(text);
			double oaValue = dateTime.ToOADate();
			cell.CellValue = new CellValue(oaValue.ToString(CultureInfo.InvariantCulture));
		}
		_worksheetPart.Worksheet.Save();
	}
