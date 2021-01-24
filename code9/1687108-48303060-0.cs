    using System;
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    // Open the document for editing.
    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
    {
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
    
        foreach (Row r in sheetData.Elements<Row>())
        {
        
        }
    }
    
