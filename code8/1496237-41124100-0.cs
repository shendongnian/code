    string newPath = @"C:\MyPath\test.xlsx";
    // read the workbook
    IWorkbook wb;
    using (FileStream fs = new FileStream(newPath, FileMode.Open, FileAccess.Read))
    {
        wb = new XSSFWorkbook(fs);
    }
    // make changes
    ISheet s = wb.GetSheetAt(0);
    IRow r = s.GetRow(0) ?? s.CreateRow(0);
    ICell c = r.GetCell(1) ?? r.CreateCell(1);
    c.SetCellValue("test2");
    // overwrite the workbook using a new stream
    using (FileStream fs = new FileStream(newPath, FileMode.Create, FileAccess.Write))
    {
        wb.Write(fs);
    }
