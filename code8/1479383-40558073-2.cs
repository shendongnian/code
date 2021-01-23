    var package = new ExcelPackage(new FileInfo("sample.xlsx"));
     
    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
     
    for (int i = workSheet.Dimension.Start.Column; i <= workSheet.Dimension.End.Column; i++)
    {
        for (int j = workSheet.Dimension.Start.Row; j <= workSheet.Dimension.End.Row; j++)
        {
            object cellValue = workSheet.Cells[i, j].Value;
        }
    }
