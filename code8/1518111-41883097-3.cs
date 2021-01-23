	using Excel = Microsoft.Office.Interop.Excel;
	//  IMPORT OTHER REQURED CONTENTS
	
	//  CHANGE THESE VARIABLES AS PER YOUR NEED
    //  ALSO CHANGE WS_Method_Type, WS_Method_Name, sEnvironment, TestDataSet_Val  
    //  FROM BELOW LINES AS PER YOUR INPUT VARIABLE NAMES
	String wsMethodType 	= this.CodeActivity16.Input.WS_Method_Type.ToString();
	String wsMethodName 	= this.CodeActivity16.Input.WS_Method_Name;
	String env 				= this.CodeActivity16.Input.sEnvironment;
	String testDataSetVal	= this.CodeActivity16.Input.TestDataSet_Val.ToString();
	String sheetName		= "Sheet1";
	String srcFile			= @"PATH \ TO \ YOUR \ XLSX \ FILE";
	Excel.Application xlApp = null;
	Excel.Workbook wb		= null;
	Excel.Worksheet worksheet = null;
	Excel.Range excelCell	= null;
	xlApp = new Excel.ApplicationClass();
	//xlApp.Visible = true;		//  UN-COMMENT ME TO SEE EXCEL
	if (xlApp == null)
	{
		CodeActivity16.Report("Excel error","Excel could not be started");
	}
	//  OPENING EXCEL TO WRITE THE DATA		
	wb = xlApp.Workbooks.Open(srcFile,
									   0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
									   true, false, 0, true, false, false);
	worksheet = (Excel.Worksheet)wb.Worksheets[sheetName];
	int lastUsedRow = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell,Type.Missing).Row;
	//  LET'S WRITE INPUT VARIABLE VALUES TO COLUMN A:D IN LAST ROW
	//  CHANGE IT AS PER YOUR NEED
	excelCell 		= (Excel.Range)worksheet.get_Range("A" + lastUsedRow, "A" + lastUsedRow);
	excelCell.Value = wsMethodType;
	excelCell 		= (Excel.Range)worksheet.get_Range("B" + lastUsedRow, "B" + lastUsedRow);
	excelCell.Value = wsMethodName;
	excelCell 		= (Excel.Range)worksheet.get_Range("C" + lastUsedRow, "C" + lastUsedRow);
	excelCell.Value = env;
	excelCell 		= (Excel.Range)worksheet.get_Range("D" + lastUsedRow, "D" + lastUsedRow);
	excelCell.Value = testDataSetVal;
	wb.Save();
	xlApp.Workbooks.Close();
	xlApp.Quit();  
