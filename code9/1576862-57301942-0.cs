			Application excel = new Application();
			Workbook workBook=  excel.Workbooks.Open("file.xlsx")
			Worksheet excelSheet = workBook.ActiveSheet;
			Range excelRange = excelSheet.UsedRange.Columns[1, Missing.Value] as Range;
			
			var lastNonEmptyRow = excelRange.Cells.Count;
