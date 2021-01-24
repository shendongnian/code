    public Task<DataTable> ParseExcel(string filePath)
    {
        return Task.Run(() =>
        {
            ExcelFile excelBook = ExcelFile.Load(filePath);
            ExcelWorksheet excelSheet = excelBook.Worksheets[0];
    
            CreateDataTableOptions options = new CreateDataTableOptions();
            return excelSheet.CreateDataTable(options);
        });
    }
