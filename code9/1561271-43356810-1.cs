	using Excel = Microsoft.Office.Interop.Excel;
	
	Excel.Application xlApp 	= null;
	Excel.Workbook wb 			= null;
	Excel.Worksheet worksheet 	= null;
	int lastUsedRow 			= 0;
	int lastUsedColumn 			= 0;
	string srcFile 				= @"Path to your XLSX file";
		
	xlApp = new Excel.ApplicationClass();
	xlApp.Visible = false;
	wb = xlApp.Workbooks.Open(srcFile,
								   0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
								   true, false, 0, true, false, false);
	worksheet = (Excel.Worksheet)wb.Worksheets[1];
	Excel.Range range
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
	xlApp.Workbooks.Close();
	xlApp.Quit();
	Marshal.ReleaseComObject(worksheet);
	Marshal.ReleaseComObject(wb);
	Marshal.ReleaseComObject(xlApp);
