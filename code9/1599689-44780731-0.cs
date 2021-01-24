    public static void CreateConditionalWorkbook(string filepath)
    {
        using (SpreadsheetDocument document = SpreadsheetDocument.
            Create(filepath, SpreadsheetDocumentType.Workbook))
        {
            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet();
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet" };
            sheets.Append(sheet);
            workbookPart.Workbook.Save();
            var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
            WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = new Stylesheet();
            Fills fills = new Fills() { Count = 1U };
            DifferentialFormats differentialFormats = new DifferentialFormats() { Count = (UInt32Value)1U };
            ConditionalFormatting conditionalFormatting = new ConditionalFormatting() { SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A1:XFD1048576" } };
            DifferentialFormat differentialFormat = new DifferentialFormat();
            Fill fill = new Fill();
            PatternFill patternFill = new PatternFill();
            BackgroundColor backgroundColor = new BackgroundColor() { Rgb = new HexBinaryValue() { Value = "ff0000" } };
            patternFill.Append(backgroundColor);
            fill.Append(patternFill);
            differentialFormat.Append(fill);
            differentialFormats.Append(differentialFormat);
            Formula formula1 = new Formula();
            formula1.Text = "\"Change\"";
            ConditionalFormattingRule conditionalFormattingRule = new ConditionalFormattingRule()
            {
                Type = ConditionalFormatValues.CellIs,
                FormatId = 0U,
                Priority = 1,
                Operator = ConditionalFormattingOperatorValues.Equal
            };
            conditionalFormattingRule.Append(formula1);
            conditionalFormatting.Append(conditionalFormattingRule);
            worksheetPart.Worksheet.Append(conditionalFormatting);
            stylesPart.Stylesheet.Append(differentialFormats);
            Random r = new Random();
            for (uint rowId = 1; rowId <= 20; rowId++)
            {
                Row row = new Row() { RowIndex = rowId };
                for (int cellId = 0; cellId < 10; cellId++)
                {
                    Cell cell = new Cell();
                    cell.CellReference = string.Format("{0}{1}", (char)(65 + cellId), rowId);
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(r.Next(2) % 2 == 0 ? "a" : "Change");
                    row.Append(cell);
                }
                sheetData.Append(row);
            }
            workbookPart.Workbook.Save();
            document.Close();
        }
    }
	
