    // Name a cell (here: the active cell in the active Excel sheet)
    Excel.Range cell = Globals.ThisAddIn.Application.ActiveCell;
    cell.Name = "MyMarkedCell";
    // Get a cell by its name
    Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet;
    Excel.Range cell = sheet.get_Range("MyMarkedCell");
    // Careful: get_Range throws an Exception, when there is no cell with the given name. 
