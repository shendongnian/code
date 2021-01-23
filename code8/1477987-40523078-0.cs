    public MemoryStream Download() {
        MemoryStream memStream;
        using (var package = new ExcelPackage()) {
            var worksheet = package.Workbook.Worksheets.Add("New Sheet");
            worksheet.Cells[1, 1] = "ID";
            worksheet.Cells[1, 2] = "Name";
            worksheet.Cells[2, 1] = "1";
            worksheet.Cells[2, 2] = "One";
            worksheet.Cells[3, 1] = "2";
            worksheet.Cells[3, 2] = "Two";  
            memStream = new MemoryStream(package.GetAsByteArray());
        }
        return memStream;
    }    
