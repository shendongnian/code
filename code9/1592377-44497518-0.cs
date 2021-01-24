	string text = dataGridView1.Columns[j].Name; 
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
			SaveChanges();
			return;
		}
	}
	// The text does not exist in the part. Create the SharedStringItem.
	var item = sharedStringTablePart.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
	cell.CellValue = new CellValue(item.ElementsBefore().Count().ToString());
