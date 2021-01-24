    public static void UpdateCell(string docName, string text, uint rowIndex, string columnName)
    {
        using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
        {
            WorksheetPart worksheetPart = GetWorksheetPartByName(spreadSheet, "Commercial");
            if (worksheetPart != null)
            {
                // Create new Worksheet
                Worksheet worksheet = new Worksheet();
                worksheetPart.Worksheet = worksheet;
                // Create new SheetData
                SheetData sheetData = new SheetData();
                // Create new row
                Row row = new Row(){ RowIndex = rowIndex };
                // Create new cell
                Cell cell = new Cell() { CellReference = columnName + rowIndex, DataType = CellValues.Number, CellValue = new CellValue(text) };
                // Append cell to row
                row.Append(cell);
                // Append row to sheetData
                sheetData.Append(row);
                // Append sheetData to worksheet
                worksheet.Append(sheetData);
                worksheetPart.Worksheet.Save();
            }
            spreadSheet.WorkbookPart.Workbook.Save();
        }
    }
