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
                        var numerFormat = numberingFormats.ElementAt((int) cell.StyleIndex.Value - 1) as NumberingFormat;
                        if (numerFormat.FormatCode.Value == "[$-409]mmmm\\ d\\,\\ yyyy;@")
                        {
                            Console.WriteLine(DateTime.FromOADate(double.Parse(cell.InnerText)).ToString("MMMM dd,yyyy"));
                        }
                        else if (numerFormat.FormatCode.Value == "[$-409]dd\\-mmm\\-yy;@")
                        {
                            Console.WriteLine(DateTime.FromOADate(double.Parse(cell.InnerText)).ToString("dd-MMM-yy"));
                        }
                    }
                    else
                    {
                        //Numeric
                        Console.WriteLine(int.Parse(cell.InnerText));
                    }
                }
                else if (cell.DataType.Value == CellValues.SharedString)
                {
                    Console.WriteLine(stringTable.SharedStringTable.ElementAt(int.Parse(cell.InnerText)).InnerText);
                }
            }
