    static void Main(string[] args)
    {
        using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(@"C:\UserTemp\Test\TestFormat.xlsx")))
        {
            OfficeOpenXml.ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            var img = worksheet.Drawings.AddPicture("Test", new FileInfo(@"C:\UserTemp\Test\Testfile.jpg"));
            img.SetPosition(4, 0, 5, 0);
            var width = (int)Math.Round(img.Image.Width * 96.0 / img.Image.HorizontalResolution);
            var height = (int)Math.Round(img.Image.Height * 96.0 / img.Image.VerticalResolution);
            var adjustedWidth = AdjustExcelPageViewImageWidth(width);
            img.SetSize(adjustedWidth, height);
            package.SaveAs(new FileInfo(@"C:\UserTemp\Test\TestFormat2.xlsx"));
        }
    }
