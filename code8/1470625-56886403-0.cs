    var newFile = new FileInfo("example.xlsx");
    using (var package = new ExcelPackage(newFile))
    {
    var worksheet = package.Workbook.Worksheets.Add("Example");
    worksheet.Cells[1, 1].RichText.Add("Hello").Bold = true;
    worksheet.Cells[1, 1].RichText.Add(" World").Bold = false;
    
    package.Save();
    }
