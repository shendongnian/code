    public void Yahfoufi(string excelFile)
    {
        var exapp = new Microsoft.Office.Interop.Excel.Application {Visible = true};
        var wrb = exapp.Workbooks.Open(excelFile);
        var sh = wrb.Sheets["Sheet1"];
        var lastRow = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByRows);
        var lastCol = GetLastIndexOfNonEmptyCell(exapp, sh, XlSearchOrder.xlByColumns);
    	
        // Clear the columns
    	sh.Range(sh.Cells(1, lastCol + 1), sh.Cells(1, Columns.Count)).EntireColumn.Clear();
        
        // Clear the remaining cells
        sh.Range(sh.Cells(lastRow + 1, 1), sh.Cells(Rows.Count, lastCol)).Clear();
    
    }
