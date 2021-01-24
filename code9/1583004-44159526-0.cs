    public void WriteValueToCell(string filepath, string sheetName, Dictionary<string, List<string>> contentList)
            {
                // Create a spreadsheet document by supplying the filepath.
                // By default, AutoSave = true, Editable = true, and Type = xlsx.
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook, true))
                {
                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();
    
                    //Add a WorkbookStylesPart to the workbookpart
                    WorkbookStylesPart stylesPart = workbookpart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = new Stylesheet();
    
                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());
    
                    // Add Sheets to the Workbook.
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
    
                    // Append a new worksheet and associate it with the workbook.
                    Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = sheetName };
                    sheets.Append(sheet);
    
                    // Get the sheetData cell table.
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
    
                    char columnName = 'I';
                    uint rowNumber = 1;
                    foreach (var keys in contentList.Keys)
                    {
                        foreach (var value in contentList.Where(v => v.Key == keys).SelectMany(v => v.Value))
                        {
                            string cellAddress = String.Concat(columnName, rowNumber);
                            // Add a row to the cell table.
                            Row row;
                            row = new Row() { RowIndex = rowNumber };
                            sheetData.Append(row);
    
                            // In the new row, find the column location to insert a cell.
                            Cell refCell = null;
                            foreach (Cell cell in row.Elements<Cell>())
                            {
                                if (string.Compare(cell.CellReference.Value, cellAddress, true) > 0)
                                {
                                    refCell = cell;
                                    break;
                                }
                            }
    
                            // Add the cell to the cell table.
                            Cell newCell = new Cell() { CellReference = cellAddress };
                            row.InsertBefore(newCell, refCell);
                            // Set the cell value to be a numeric value.
                            newCell.CellValue = new CellValue(value);
                            newCell.DataType = new EnumValue<CellValues>(CellValues.String);
    
                            int tempColumn = (int)columnName;
                            columnName = (char)++tempColumn;
                        }
                        columnName = 'I';
                        ++rowNumber;
                    }
                }
            }
