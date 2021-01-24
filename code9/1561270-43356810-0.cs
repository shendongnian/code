	// Find the last real row
	lastUsedRow = worksheet.Cells.Find("*",System.Reflection.Missing.Value, 
								   System.Reflection.Missing.Value, System.Reflection.Missing.Value, 
								   Excel.XlSearchOrder.xlByRows,Excel.XlSearchDirection.xlPrevious, 
								   false,System.Reflection.Missing.Value,System.Reflection.Missing.Value).Row;
	
	// Find the last real column
	lastUsedColumn = worksheet.Cells.Find("*", System.Reflection.Missing.Value, 
								   System.Reflection.Missing.Value,System.Reflection.Missing.Value, 
								   Excel.XlSearchOrder.xlByColumns,Excel.XlSearchDirection.xlPrevious, 
								   false,System.Reflection.Missing.Value,System.Reflection.Missing.Value).Column;
