    var outFile = Path.ChangeExtension(filePath, ".xlsx");
    using (var p = new ExcelPackage())
    {
        var fmt = new ExcelTextFormat();
        fmt.Delimiter = '\t';
        fmt.SkipLinesBeginning = 2;
        fmt.SkipLinesEnd = 1;
        var ws = p.Workbook.Worksheets.Add("Imported Text");
        ws.Cells[1, 1].LoadFromText(new FileInfo(filePath), fmt, TableStyles.Medium27, false);
        p.SaveAs(new FileInfo(outFile));
    }
