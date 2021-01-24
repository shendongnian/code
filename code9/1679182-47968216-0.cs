    var file= new FileInfo(path);
    using (var package = new ExcelPackage(file))
    {
        var sheet = package.Workbook.Worksheets["Sheet1"];
        var cell = sheet.Cells["A1"];
       
        if(cell.Value is DateTime)
        {
              //logic for datetime
        }
        else if(cell.Value is double)
        {
              //you get the point :)
        }        
    }
