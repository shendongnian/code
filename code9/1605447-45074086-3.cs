    private void GenerateWorkSheetsParts(WorkbookPart workbookPart, List<DataObject> data)
            {
                for (int i = 1; i < data.Count+2; i++)
                {
                    var relId = "rId" + i;
                    if (i == 1)
                    {
                        WorksheetPart workSheetPart = workbookPart.AddNewPart<WorksheetPart>(relId);
                        GenerateWorkSheetPartContent(workSheetPart, i, data);
                    }
                    else
                    {
                        WorksheetPart workSheetPart = workbookPart.AddNewPart<WorksheetPart>(relId);
                        GenerateWorkSheetPartContent(workSheetPart, i, data[i-2].NestedObject);
                    }
    
                }
            }
     private void GenerateWorkSheetPartContent(WorksheetPart worksheetPart,int indexer, List<NestedObject> data)
            {
    
                Worksheet worksheet = new Worksheet();
                SheetData sheetData = new SheetData();
                Hyperlinks hyperlinks = new Hyperlinks();
    
                if (indexer == 1)
                {
                    sheetData.AppendChild(ConstructHeader("Unique errors", "Count"));
                    
                    foreach (var @event in data)
                    {
                        indexer++;
                        Row row = new Row();
                        row.Append(ConstructCell(@event.ErrorMessage, "A" + indexer, CellValues.String), ConstructCell(@event.ListOfErrorsObject.Count.ToString(), CellValues.Number));
                        sheetData.AppendChild(row);
                        Hyperlink hyperlink = new Hyperlink()
                        {
                            Reference = "A" + indexer,
                            Location = "Unique" + (indexer - 1)+"!A1",
                            Display = "Unique" + indexer
                        };
                        hyperlinks.AppendChild(hyperlink);
                    }
                    worksheet.Append(sheetData, hyperlinks);
                    worksheetPart.Worksheet = worksheet;
                }
                else
                {
                    worksheet.AppendChild(sheetData);
                    worksheetPart.Worksheet = worksheet;
                }
            }
