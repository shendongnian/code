    var fileName = "test.xlsx";
    var sl = new SLDocument(fileName);
    foreach (var sheetName in sl.GetWorksheetNames())
    {
        SLDocument sheet = new SLDocument(fileName, sheetName);
        sheet.SetCellValue("A1", "foo");
        sheet.SetCellValue("B1", "bar");
        SLWorksheetStatistics stats = sheet.GetWorksheetStatistics();
        int endColumnIndex = stats.EndColumnIndex;
        var headers = new List<string>();
        for (int i = 1; i <= endColumnIndex; i++)
        {
            headers.Add(sheet.GetCellValueAsString(1, i));
        }
        foreach (var column in headers)
        {
            Console.WriteLine(column);
        }
        Console.ReadKey();
    }
