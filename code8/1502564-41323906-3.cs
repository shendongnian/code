    FileInfo filePath = new FileInfo("ExcelDemo.xlsx");
    
    if (File.Exists(filePath.ToString()))
    {
        File.Delete(filePath.ToString());
    }
    
    using (ExcelPackage pck = new ExcelPackage(filePath))
    {
        var schedule = pck.Workbook.Worksheets.Add("Schedule");
        var cart = pck.Workbook.Worksheets.Add("Cartridge");
        var unsche = pck.Workbook.Worksheets.Add("Unschedule");
        var rekap = pck.Workbook.Worksheets.Add("Rekap");
    
        pck.SaveAs(filePath);
    }
    
    using (ExcelPackage pck = new ExcelPackage(filePath))
    {
        var rekap = pck.Workbook.Worksheets["Rekap"];
        var schedule = pck.Workbook.Worksheets["Schedule"];
    
        rekap.Cells[4, 1].Value = "Added data";
        schedule.Cells[4, 1].Value = "Added data";
    
        pck.SaveAs(filePath);
    }
