    var values = new List<object[]>()
    { 
        new string[] { "0.001", "1.001", "2.002" }, 
        new string[] { "3.003", "4.004", "5.005" },
        new string[] { "6.006", "7.007", "8.008" }
    };
    
    using (var package = new ExcelPackage())
    {
        var sheet = package.Workbook.Worksheets.Add("Sheet1");
        sheet.Cells["A1"].LoadFromArrays(values);
        foreach (var cell in sheet.Cells["C:C"])
        {
            cell.Value = Convert.ToDecimal(cell.Value);
        }
        sheet.Cells["C:C"].Style.Numberformat.Format = "#,##0.00";
        File.WriteAllBytes(OUTPUT, package.GetAsByteArray());
    }
