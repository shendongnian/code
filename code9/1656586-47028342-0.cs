    using (var sourceExcel = new ExcelPackage(new FileInfo("multisheet.xlsx")))
    {
        var sheetsToCopy = sourceExcel.Workbook.Worksheets;
        foreach(var sheetToCopy in sheetsToCopy)
        {
            using (var destExcel = new ExcelPackage())
            {
                destExcel.Workbook.Worksheets.Add(sheetToCopy.Name, sheetToCopy);
                destExcel.SaveAs(new FileInfo(sheetToCopy.Name + ".xlsx"));
            }
        }
    }
