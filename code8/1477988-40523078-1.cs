    public MemoryStream Download() {
        MemoryStream memStream;
        using (var package = new ExcelPackage()) {
            var worksheet = package.Workbook.Worksheets.Add("New Sheet");
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Name";
            worksheet.Cells[2, 1].Value = "1";
            worksheet.Cells[2, 2].Value = "One";
            worksheet.Cells[3, 1].Value = "2";
            worksheet.Cells[3, 2].Value = "Two";  
            memStream = new MemoryStream(package.GetAsByteArray());
        }
        return memStream;
    }    
