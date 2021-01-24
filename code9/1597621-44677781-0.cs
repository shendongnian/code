    var path = @"C:\Temp\EPPlus Demo.xlsx";
    
    var fi = new FileInfo(path);
    if (fi.Exists)
        fi.Delete();
    
    using (var pck = new ExcelPackage())
    {
        var wb = pck.Workbook;
        var ws = wb.Worksheets.Add("Demo");
        ws.Cells["A1"].LoadFromCollection(list.ToListExport(), true);
        for (var r = 2; r <= ws.Dimension.Rows; r++)
        {
            ws.Cells[r, 8].Formula = $"F{r}/G{r}";
            // Or alternatively, using R1C1 format
            ws.Cells[r, 8].FormulaR1C1 = "RC[-2]/RC[-1]";
        }
        pck.SaveAs(fi);
    }
