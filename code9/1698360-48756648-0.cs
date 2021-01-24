    public IEnumerable<string> ReadFile(string path)
    {
         using(var file = new FileStream(path, FileMode.Open))
         using(var memory = new MemoryStream())
         {
              file.CopyTo(memory);
              using(var package = new ExcelPackage(memory))
                   if(package.Workbook.Worksheets.Count != 0)
                        foreach(ExcelWorksheet worksheet in package.Workbook.Worksheets)
                             for(var row = 0; worksheet.Dimension.Start.Row; row <= worksheet.Dimension.End.Row; row++)
                                  yield return worksheet.Cells[row, 2].Value;
         }
    }
