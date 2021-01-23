            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                {
                    List<string> ColumnNames = new List<string>();
                    for(int i = 1; i <= worksheet.Dimension.End.Column; i++)
                    {
                        ColumnNames.Add(worksheet.Cells[1, i].Value.ToString()); // 1 = First Row, i = Column Number
                    }
                }
            }
