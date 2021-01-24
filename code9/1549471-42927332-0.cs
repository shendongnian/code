    public static void ConvertToCsv(this ExcelPackage package, string targetFile)
    {
            var worksheet = package.Workbook.Worksheets[1];
            var maxColumnNumber = worksheet.Dimension.End.Column;
            var currentRow = new List<string>(maxColumnNumber);
            var totalRowCount = worksheet.Dimension.End.Row;
            var currentRowNum = 1;
            //No need for a memory buffer, writing directly to a file
            //var memory = new MemoryStream();
            using (var writer = new StreamWriter(targetFile,false, Encoding.UTF8))
            {
            //the rest of the code remains the same
            }
            // No buffer returned
            //return memory.ToArray();
    }
