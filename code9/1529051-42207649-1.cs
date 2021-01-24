    var file = new FileInfo("test.xlsx");
    using (var pck = new ExcelPackage(file))
    {
        var ws = pck.Workbook.Worksheets.Add("Rules");
        for(int i=0;i<= contentsHeight; i++)
            for (int j = 0; j <= contentsWidth; j++)
                ws.Cells[i+1,j+1].Value = contents[i,j];
        pck.Save();
    }
