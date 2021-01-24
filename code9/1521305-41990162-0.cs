    using (var package = new ExcelPackage(fileInfo))
    {
        package.Workbook.FullCalcOnLoad = true;
        // same result as question code if Calculate() is called instead: '#VALUE!' 
        // package.Workbook.Calculate();
        var ws = package.Workbook.Worksheets[1];
        Console.WriteLine("Country: \t{0}", ws.Cells["B1"].Value);
        Console.WriteLine("Phone Code:\t{0}", ws.Cells["B2"].Value.ToString());
    }
