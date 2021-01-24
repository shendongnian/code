    //code uses variables declared appropriately as Excel.Range & Excel.Worksheet Using Interop library
    int x;
    int y;
    // get the row of the last value content row-wise
    oRange = oSheet.Cells.Find(What: "*", 
                               After: oSheet.get_Range("A1"),
                               LookIn: XlFindLookIn.xlValues,
                               LookAt: XlLookAt.xlPart, 
                               SearchDirection: XlSearchDirection.xlPrevious,
                               SearchOrder: XlSearchOrder.xlByRows);
    if (oRange == null)
    {
        return;
    }
    x = oRange.Row;
    // get the column of the last value content column-wise
    oRange = oSheet.Cells.Find(What: "*",
                               After: oSheet.get_Range("A1"),
                               LookIn: XlFindLookIn.xlValues, LookAt: XlLookAt.xlPart,
                               SearchDirection: XlSearchDirection.xlPrevious,
                               SearchOrder: XlSearchOrder.xlByColumns);
    y = oRange.Column;
    
    // now we have the corner (x, y), we can delete or clear all content to the right and below
    // say J16 is the cell, so x = 16, and j=10
    Excel.Range clearRange;
    //set clearRange to ("K1:XFD1048576")
    clearRange = oSheet.Range[oSheet.Cells[1, y + 1], oSheet.Cells[oSheet.Rows.Count, oSheet.Columns.Count]];
    clearRange.Clear(); //clears all content, formulas and formatting
    //clearRange.Delete(); if you REALLY want to hard delete the rows
    
    //set clearRange to ("A17:J1048576")            
    clearRange = oSheet.Range[oSheet.Cells[x + 1, 1], oSheet.Cells[oSheet.Rows.Count, y]];
    clearRange.Clear(); //clears all content, formulas and formatting
    //clearRange.Delete();  if you REALLY want to hard delete the columns
