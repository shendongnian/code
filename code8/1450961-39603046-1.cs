    public bool ExportToExcel(clsDataAccess.clsDataAccess db, ref DataTable dt)
    {
    	Excel.Application xlApp = default(Excel.Application);
    	Excel.Workbook xlWorkbook = default(Excel.Workbook);
    	Excel.Worksheet xlWorkSheet = default(Excel.Worksheet);
    	object misValue = Reflection.Missing.Value;
    	int i = 0;
    	int j = 0;
    	int maxRow = dt.Rows.Count;
    	int maxColumn = dt.Columns.Count;
    	string[,] arr = new string[maxRow + 1, maxColumn + 1];
    	string callingAssembly = Reflection.Assembly.GetCallingAssembly().GetName.Name;
    
    	if (dt == null)
    		throw new Exception("Passed Data Table is set to nothing");
    
    	while (!(j > maxColumn - 1)) {
    		arr(0, j) = dt.Columns(j).ColumnName;
    		j += 1;
    	}
    
    	while (!(i > maxRow - 1)) {
    		j = 0;
    		while (!(j > maxColumn - 1)) {
    			arr(i + 1, j) = dt.Rows(i).Item(j).ToString;
    			j += 1;
    		}
    		i += 1;
    	}
    
    	xlApp = new Excel.Application[];
    	xlWorkbook = xlApp.Workbooks.Add(misValue);
    	xlWorkSheet = (Excel.Worksheet)xlWorkbook.Sheets("sheet1");
    
    	xlApp.Visible = false;
    	xlApp.ScreenUpdating = false;
    	xlApp.DisplayAlerts = false;
    
    	xlWorkSheet.Range("A1").Resize(maxRow + 1, maxColumn).Value = arr;
    	xlWorkSheet.Cells.Columns.AutoFit();
    	xlWorkSheet.Name = callingAssembly;
    
    	xlApp.ScreenUpdating = true;
    	xlWorkbook.SaveCopyAs("somefile.xlsx");
    	xlApp.Quit();
    
    	ReleaseObject(xlWorkSheet);
    	ReleaseObject(xlWorkbook);
    	ReleaseObject(xlApp);
    
    	return true;
    }
    
    private void ReleaseObject(object obj)
    {
    	Runtime.InteropServices.Marshal.ReleaseComObject(obj);
    	obj = null;
    }
