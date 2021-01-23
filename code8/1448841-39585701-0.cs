    ExcelPackage masterPackage = new ExcelPackage();
    foreach (var file in files)
    {
        ExcelPackage pckg = new ExcelPackage(new FileInfo(file));
        foreach (var sheet in pckg.Workbook.Worksheets)
        {
            //check name of worksheet, in case that worksheet with same name already exist exception will be thrown by EPPlus
            string workSheetName = sheet.Name;
            foreach (var masterSheet in masterPackage.Workbook.Worksheets)
            {
                if (sheet.Name == masterSheet.Name)
                {
                    workSheetName = string.Format("{0}_{1}", workSheetName, DateTime.Now.ToString("yyyyMMddhhssmmm"));
                }
            }
            //add new sheet
            if (sheet.Name.Contains("MB_STORE_POTENTIALvsWALLET"))
            {
                 masterPackage.Workbook.Worksheets.Add(workSheetName, sheet);
            }
            else
            {
                 masterPackage.Workbook.Worksheets.Add(workSheetName, sheet);
                 masterPackage.Workbook.Worksheets.MoveBefore(2, 1);
            }
        }
    }
    masterPackage.SaveAs(new FileInfo(resultFile));
