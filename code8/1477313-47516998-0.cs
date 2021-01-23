    var filePath = @"D:/test.xlsx";
    FileInfo file = new FileInfo(filePath);
    
    using (ExcelPackage package = new ExcelPackage(file))
    {       
        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
        int rowCount = worksheet.Dimension.Rows;
        int ColCount = worksheet.Dimension.Columns;
    
        var rawText = string.Empty;
        for (int row = 1; row <= rowCount; row++)
        {
            for (int col = 1; col <= ColCount; col++)
            {   
                // This is just for demo purposes
                rawText += worksheet.Cells[row, col].Value.ToString() + "\t";    
            }
            rawText+="\r\n";
        }
        _logger.LogInformation(rawText);
    }
