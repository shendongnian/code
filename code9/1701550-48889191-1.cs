    var sheetNames = new List<string> { "Summary", "EmployeeData", "Benefits" };
    for (var i = 0; i < ds.Tables.Count; i++)
    {
        // Choose a name from the list or use 'Sheet1, 2, 3' if we don't have enough names
        var sheetName = i < sheetNames.Count 
            ? sheetNames[i] 
            : String.Format("Sheet{0}", sheetNames.Count - i);
        var ws = package.Workbook.Worksheets.Add(sheetName);
