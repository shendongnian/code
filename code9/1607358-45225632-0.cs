    using Excel = Microsoft.Office.Interop.Excel; // skip a lot of redundant typing
    // declare application/workbook/worksheet objects
    Excel.Application applicationObject = new Excel.Application();
    Excel.Workbook workbookObject;
    Excel.Worksheet worksheetObject;
    
    workbookObject = applicationObject.Open(/* lot of parameters go here */);
    worksheetObject = workbookObject.Sheets["SheetName"];
    DoThings(worksheetObject);
    // finished working with sheet, time to close it
    workbookObject.SaveAs(/* necessary parameters */);
    workbookObject.Close(/* necessary parameters */);
