    public static void CreateFile(string filename)
    {
        using (SpreadsheetDocument spreadsheetDocument = 
            SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook))
        {
            // Add a WorkbookPart to the document.
            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();
            workbookpart.AddNewPart<WorkbookStylesPart>();
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            // Add Sheets to the Workbook.
            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
            // Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet()
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet 1"
            };
            sheets.Append(sheet);
            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();
            Stylesheet styleSheet = CreateStyles();
            Row row = CreateRow();
            sheetData.Append(row);
            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;
            workbookpart.WorkbookStylesPart.Stylesheet = styleSheet;
            // Close the document.
            spreadsheetDocument.Close();
        }
    }
    private static Row CreateRow()
    {
        Row row = new Row();
        DateTime now = DateTime.UtcNow;
        //add a date cell using the number data type
        Cell cell = new Cell();
        cell.StyleIndex = 0;
        cell.DataType = CellValues.Number;
        string columnValue = now.ToOADate().ToString();
        cell.CellValue = new CellValue(columnValue);
        row.Append(cell);
        //add a date cell using the date data type
        Cell cell2 = new Cell();
        cell2.StyleIndex = 0;
        cell2.DataType = CellValues.Date;
        columnValue = now.ToString("o");
        cell2.CellValue = new CellValue(columnValue);
        row.Append(cell2);
        return row;
    }
