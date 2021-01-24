    SLDocument sl = new SLDocument();
    sl.SetCellValue("A1", "foo");
    sl.SetCellValue("B1", "bar");
    SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
    int endColumnIndex = stats.EndColumnIndex;
    var headers = new List<string>();
    for (int i = 1; i <= endColumnIndex; i++)
    {
        headers.Add(sl.GetCellValueAsString(1, i));
    }
    foreach (var column in headers) {
        Console.WriteLine(column);
    }
    Console.ReadKey();
