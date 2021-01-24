    // Prepare your reader by 
    var stream = File.Open(yourExcelFilename, FileMode.Open, FileAccess.Read);
    var excelDataReader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(stream);
    // This variable will store visible worksheet names
    List<string> visibleWorksheetNames;
    // Use a loop to read workbook    
    visibleWorksheetNames = new List<string>();
    for (var i = 0; i < excelDataReader.ResultsCount; i++)
    {
        // checking visible state
        if (excelDataReader.VisibleState == "visible")
        {
            visibleWorksheetNames.Add(excelDataReader.Name);
        }
        excelDataReader.NextResult();
    }
