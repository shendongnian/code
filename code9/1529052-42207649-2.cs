    var file = new FileInfo("test.xlsx");
    using (var pck = new ExcelPackage(file))
    {
        var ws = pck.Workbook.Worksheets.Add("Rules");
        ws.LoadFromDataTable(myTable);
        pck.Save();
    }
