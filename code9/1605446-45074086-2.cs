    private void GenerateWorkbookPart(WorkbookPart workbookPart, int dataCount)
            {
    
                Workbook workbook = new Workbook();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                for (int i = 1; i < dataCount+2; i++)
                {
                    var relId = "rId" + i;
                    if (i == 1)
                    {
                        sheet = new Sheet()
                        {
                            Name = "Main",
                            SheetId = (uint) i,
                            Id = relId
                        };
                    }
                    else
                    {
                        sheet = new Sheet()
                        {
                            Name = "Unique" + (i-1),
                            SheetId = (uint)i,
                            Id = relId
                        };
                    }
    
                    sheets.AppendChild(sheet);
                }
                workbook.AppendChild(sheets);
                workbookPart.Workbook = workbook;
            }
