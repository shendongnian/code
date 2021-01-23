    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(filename, true))
    {
        WorkbookPart workBookPart = spreadsheetDocument.WorkbookPart;
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        //create a row
        Row row1 = new Row() { RowIndex = 1U };
        //create a new inline string cell
        Cell cell = new Cell() { CellReference = "A1" };
        cell.DataType = CellValues.InlineString;
        //create a run for the bold text
        Run run1 = new Run();
        run1.Append(new Text("ABC"));
        //create runproperties and append a "Bold" to them
        RunProperties run1Properties = new RunProperties();
        run1Properties.Append(new Bold());
        //set the first runs RunProperties to the RunProperties containing the bold
        run1.RunProperties = run1Properties;
                
        //create a second run for the non-bod text
        Run run2 = new Run();
        run2.Append(new Text(Environment.NewLine + "XYZ") { Space = SpaceProcessingModeValues.Preserve });
        //create a new inline string and append both runs
        InlineString inlineString = new InlineString();
        inlineString.Append(run1);
        inlineString.Append(run2);
        //append the inlineString to the cell.
        cell.Append(inlineString);
        //append the cell to the row
        row1.Append(cell);
        sheetData.Append(row1);
    }
