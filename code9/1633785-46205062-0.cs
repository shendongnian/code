        public static void mergeExcelFiles()
        {
            string template = @"Template.xlsx"; // look in your bin folder
            string fileName = @"Test.xlsx";
            File.Copy(template, fileName, true);
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, true))
            {
                // Instatiate new SheetData
                SheetData sheetData = new SheetData();
                // Instatiate WorkbookPart from SpreadsheetDocument
                WorkbookPart workbookPart = document.WorkbookPart;
                // Get the (first)worksheet
                //Sheet theSheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == "Sheet1").FirstOrDefault();
                Sheet theSheet = workbookPart.Workbook.Descendants<Sheet>().First();
                if (theSheet != null)
                {
                    sheetData = ((WorksheetPart)workbookPart.GetPartById(theSheet.Id)).Worksheet.GetFirstChild<SheetData>();
                }
                Row row = new Row();
                Cell cell = new Cell();
                cell.DataType = CellValues.InlineString;
                cell.CellReference = "A2";
                Text text = new Text("Some text");
                InlineString inlineString = new InlineString(text);
                cell.AppendChild(inlineString);
                row.RowIndex = (UInt32)2;
                row.AppendChild(cell);
                // Append new row to SheetData
                sheetData.AppendChild(row);
                workbookPart.Workbook.Save();
            }
        }
