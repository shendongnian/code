    enum ExcelFileTestResult
    {
        FileNotFound,
        ValidFormat, //File found, valid excel
        InvalidFormat //File found but not valid excel
    }
       
    public static ExcelFileTestResult CheckExcelFile(string path)
    {
        ExcelFileTestResult result = ExcelFileTestResult.FileNotFound;
        if (File.Exists(path))
        {
            FileInfo fi = new FileInfo(path);
            try
            {
                // Trying to read file using EPPlus
                // if the file is not valid format, it will throw error
                using (ExcelPackage p = new ExcelPackage(fi))
                {
                    result = ExcelFileTestResult.ValidFormat;
                }
            }
            catch (InvalidDataException ex)
            {
                result = ExcelFileTestResult.InvalidFormat;
            }
        }
        return result;
    }
