    using (var package = new ExcelPackage(new FileInfo(@"a.xslx")))
    {
        if (!package.Workbook.Worksheets.Any())
            package.Workbook.Worksheets.Add("sheet");
	    var sheet = package.Workbook.Worksheets.First();
        var appendRow = sheet.Dimension.Rows + 1;
        sheet.Cells[appendRow, 1].LoadFromDataTable(new DataTable(), false);
        package.SaveAs(new FileInfo(@"a.xslx"));
    }
