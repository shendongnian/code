    var path = @"C:\Temp";
    var excelFileName = $@"{path}\Sample.xlsx";
	var excelApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application") as Excel.Application;
    // Make the object visible.
    excelApp.Visible = true;
	// open workbook
	Excel.Workbook xlWorkbook = excelApp.Workbooks.Open(excelFileName);
