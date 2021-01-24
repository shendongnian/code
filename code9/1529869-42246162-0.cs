	int maxColNo = sheet.LastColumnUsed().ColumnNumber();
	foreach (var row in sheet.RowsUsed())
	{
		for (int colNo = maxColNo; colNo > 0; colNo--)
		{
			if (row.Cell(colNo).IsEmpty())
			{
				row.Cell(colNo).Delete(XLShiftDeletedCells.ShiftCellsLeft);
			}
		}
	}
