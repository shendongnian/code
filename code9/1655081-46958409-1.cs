    ExcelPackage pck = new ExcelPackage();
    var ws = pck.Workbook.Worksheets.Add("Sample1");
    // Build the sheet then ...
    var blockBlob = container.GetBlockBlobReference("somefile.xlsx");
    using(var stream=blockBlob.OpenWrite())
    {
        pck.SaveAs(stream);
    }
