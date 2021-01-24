    using (var xlPackage = new ExcelPackage(new FileInfo(somePath))
    {
        // add a sheet
        var ws = xlPackage.Workbook.Worksheets.Add("Sheet1");
        var table = ws.Tables.Add(range, "table1");
        table.ShowTotal = true;
        table.TableStyle = TableStyles.Light2;
        ...
    }
