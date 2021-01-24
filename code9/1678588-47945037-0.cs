    static void Main(string[] args)
    {
        var myFileInfo = new FileInfo("input.xlsx");
        using (var excel = new ExcelPackage())
        {
            var worksheet = excel.Workbook.Worksheets.Add("sheet1");
            var charWidthOfFirstColumn = worksheet.Column(1).Width;
            var widthInCm = charWidthOfFirstColumn * 0.211666;
        }
    }
