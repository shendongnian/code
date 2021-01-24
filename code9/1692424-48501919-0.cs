    var xl = Globals.ThisAddIn.Application;
    var dest = xl.ActiveWorkbook;
    var dpfad = dest.FullName;
    dest.Close();
    var xdest = new XLWorkbook(dpfad);
    var org = new XLWorkbook(pfad);
    foreach (IXLWorksheet sheet in org.Worksheets)
    {
    	var used = sheet.RangeUsed(true);
    	IXLWorksheet dsheet;
    	xdest.TryGetWorksheet(sheet.Name, out dsheet);
    
    	foreach (IXLCell cel in used.Cells(false))
    	{
    		var dcel = dsheet.Range(cel.WorksheetRow().RowNumber(),
    			cel.WorksheetColumn().ColumnNumber(), cel.WorksheetRow().RowNumber(),
    			cel.WorksheetColumn().ColumnNumber());
    		dcel.Style = cel.Style;
    	}
    }
    xdest.Save();
    xdest.Dispose();
    org.Dispose();
    xl.Workbooks.Open(dpfad);
