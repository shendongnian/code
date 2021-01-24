    public static void WriteExcel()
            {
                Dictionary<int, int> dictionary =
                new Dictionary<int, int>();
    
                for (int i = 1; i <= 100; i++)
                {
                    dictionary.Add(i, i);
                }   
                
                var filePath = @"C:/Sample.xlsx";             
                var file = new FileInfo(filePath);
    
                using (var package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                    int k = 0;
                    foreach (var item in dictionary.Take(50))
                    {
                        int cell = k + 2;
                        worksheet.Cells["A" + cell].Value = item.Value;
                        k++;
                    }
                    package.Save();
                }
            }
