    var doc = SpreadsheetDocument.Open(File.Open("D:\\123.xlsx", FileMode.Open), false);
            var sheet = doc.WorkbookPart.Workbook.Descendants<Sheet>().FirstOrDefault();
            WorksheetPart wsPart = (WorksheetPart)(doc.WorkbookPart.GetPartById(sheet.Id));
            var cells = wsPart.Worksheet.Descendants<Cell>().ToList();
            var numberingFormats = doc.WorkbookPart.WorkbookStylesPart.Stylesheet.NumberingFormats.ToList();
            var stringTable = doc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
            foreach (var cell in cells)
            {
                if (cell.DataType == null)
                {
                    //DateTime 
                    if (cell.StyleIndex != null)
                    {
                        if (numberingFormats.ElementAt((int) cell.StyleIndex.Value - 1) != null)
                        {
                            var dateTime = DateTime.FromOADate(double.Parse(cell.InnerText));
                        }
                    }
                    else
                    {
                        //Numeric
                        var value = int.Parse(cell.InnerText);
                    }
                }
                else if (cell.DataType.Value == CellValues.SharedString)
                {
                    var value = stringTable.SharedStringTable.ElementAt(int.Parse(cell.InnerText)).InnerText;
                }
            }
