    public IEnumerable<XlsxFile> import(string xlsxFilePath, string SheetName)
    {
        using (var excel = new ExcelQueryFactory(xlsxFilePath))
        {
            return from x in excel.Worksheet<XlsxFile>(SheetName) where x != null select x;
        }
    }
