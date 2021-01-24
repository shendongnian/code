    // using NPOI.HSSF.UserModel;
    string[] files = Directory.GetFiles(@"c:\temp\excel");
    HSSFWorkbook workbookMerged = new HSSFWorkbook();
    foreach (string file in files)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        {
            workbook = new HSSFWorkbook(fs);
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                ((HSSFSheet)workbook.GetSheetAt(i)).CopyTo(workbookMerged, workbook.GetSheetName(i), true, true);
            }
        }
    }
    using (FileStream fs = new FileStream(@"c:\temp\excel\output\testFile.xls", FileMode.Append, FileAccess.Write))
    {
        workbookMerged.Write(fs);
    }
