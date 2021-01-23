     private void ExportToExl(bool firstTime)
            {
               //string path = string.Empty;               
                //Delete the file if it exists. 
                if (firstTime && File.Exists(savingFileName))
                    File.Delete(savingFileName);
         
                if (firstTime)
                {
                    //This is the first time of creating the excel file and the first sheet.
                    // Create a spreadsheet document by supplying the filepath.
                    // By default, AutoSave = true, Editable = true, and Type = xlsx.
                    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.
                        Create(savingFileName, SpreadsheetDocumentType.Workbook);
    
                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
    
                    // Add a WorksheetPart to the WorkbookPart.
                    var worksheetPart = workbookpart.AddNewPart<WorksheetPart>(); 
                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                    var bold1 = new System.Windows.Documents.Bold();
                    DocumentFormat.OpenXml.Spreadsheet.CellFormat cf = new DocumentFormat.OpenXml.Spreadsheet.CellFormat();
    
                    // Add Sheets to the Workbook.
                    DocumentFormat.OpenXml.Spreadsheet.Sheets sheets;
                    sheets = spreadsheetDocument.WorkbookPart.Workbook.
                        AppendChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>(new DocumentFormat.OpenXml.Spreadsheet.Sheets());
    
                    // Append a new worksheet and associate it with the workbook.
                    var sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                            GetIdOfPart(worksheetPart),
                        SheetId = sheetId,
                        Name = "Sheet" + sheetId
                    };
                    sheets.Append(sheet);
    
                    //Add Header Row.
                    var headerRow = new Row();
                    foreach (DataColumn column in ResultsData.Columns)
                    {
                        var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(column.ColumnName) };
                        headerRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(headerRow);
    
                    foreach (DataRow row in ResultsData.Rows)
                    {
                        var newRow = new Row();
                        foreach (DataColumn col in ResultsData.Columns)
                        {
                            var cell = new Cell
                            {
                                DataType = CellValues.String,
                                CellValue = new CellValue(row[col].ToString())
                            };
                            newRow.AppendChild(cell);
                        }
                        sheetData.AppendChild(newRow);
                    }               
                    workbookpart.Workbook.Save();
                    spreadsheetDocument.Close();
                }
        }
