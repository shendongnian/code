    Row row1 = worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>().FirstOrDefault();
    int counter = 0;
	foreach (Cell cell in row1.Elements<Cell>())
	{
		if (cell.CellValue != null)
		{
			Console.WriteLine(cell.CellReference);
            counter++;
		}
	}
