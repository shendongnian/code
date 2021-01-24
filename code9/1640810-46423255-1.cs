    Stopwatch stopWatch = new Stopwatch();
    
    stopWatch.Start();
    
    using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(@"c:\temp\BigSpeadsheet.xlsx", false))
    {
        WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
    
        OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
        string text;
        while (reader.Read())
        {
            if (reader.ElementType == typeof(CellValue))
            {
                text = reader.GetText();
            }
        }
    }
    
    stopWatch.Stop();
    
    Console.WriteLine("Using Open XML SDK: {0} seconds", stopWatch.ElapsedMilliseconds / 1000);
    
    Console.ReadLine();
