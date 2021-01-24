    var FileInfo = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "WriteDataToExcelThroughCode.xlsx"));
    using (ExcelPackage package = new ExcelPackage(FileInfo))
    {
        ExcelWorksheet ws = package.Workbook.Worksheets["TTest2"];
        //ExcelWorksheet ws = package.Workbook.Worksheets[0];
        int x = 24;
        foreach (var calcs in dictionary)
        {
            ws.Cells["A24:C36"].Clear();
            for (int z = 0; z <= numofrows; ++z)
            {
                ws.Cells["A" + x + ":A" + x].Value = calcs.Key;
                ws.Cells["B" + x + ":B" + x].Value = calcs.Value[0];
                ws.Cells["C" + x + ":C" + x].Value = calcs.Value[1];
                //ws.Cells["D" + x + "D" + x].Value = calcs.Value[2];
                ++x;
            }
            package.Save();
        }
    }
    
