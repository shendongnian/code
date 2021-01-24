     string filename = @"D:\test.xlsx";
                using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    string FileExtension = Path.GetExtension(filename);
                    if (FileExtension.ToLower().Equals(".xls"))
                    {
                        var HSSFWorkBook = new HSSFWorkbook(file);
                        int CountSheets = HSSFWorkBook.NumberOfSheets;
                    }
                    else if (FileExtension.ToLower().Equals(".xlsx"))
                    {
                        var XSSFWorkBook = new XSSFWorkbook(file);
                    }
                }
