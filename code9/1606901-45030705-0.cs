    static void Main(string[] args)
    {
        string fileFullPath = @"C:\Book1.xlsx";
        string sheetName = "Sheet1";
        // Specify your column index and then convert to letter format
        int columnIndex = 3;
        string columnName = GetExcelColumnName(columnIndex);
        using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileFullPath, true)) {
            Sheet sheet = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();
                
            if (sheet != null) {
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id.Value);
                // Get all the rows in the workbook
                IEnumerable<Row> rows = worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>();
                // Ensure that there are actually rows in the workbook
                if (rows.Count() == 0){
                    return;
                }
                // Select all the cells from each row where the column letter is equal to index
                foreach (Row row in rows) {
                    var cellsToRemove = row.Elements<Cell>().Where(x => new String(x.CellReference.Value.Where(Char.IsLetter).ToArray()) == columnName);
                    foreach (var cell in cellsToRemove)
                        cell.Remove();
                }
            }
        }
    }
