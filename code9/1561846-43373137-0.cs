    //
    using OfficeOpenXml;
    
    //
    read the file using file stream
    using (var stream= new StreamReader("filePath"))
    {
         // then use the stream to extract the excel specific data
         using (var excelPackage = new ExcelPackage(stream))
        {
            var sheet = excelPackage.Workbook.Worksheets[1];
            var cell1= sheet.Cells[1, 1].GetValue<string>();
        }
    }
