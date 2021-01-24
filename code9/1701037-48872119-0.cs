     using (ExcelPackage pkg = new ExcelPackage(new FileInfo(@"D:\testSheet.xlsx")))
            {
                pkg.Workbook.Worksheets.Add("sheet");
                pkg.Workbook.Worksheets.ElementAt(0).Cells["A10:A15"].Value = 2;
                pkg.Workbook.Worksheets.ElementAt(0).Cells["C5"].Formula = "SUM(LARGE(A10:A15, {1,2}))";
                pkg.Save();
            }
