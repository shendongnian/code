    static void Main(string[] args)
    {
        var fInfo = new FileInfo("output.xlsx");
        using (var excel = new ExcelPackage())
        {
            var sht1 = excel.Workbook.Worksheets.Add("DataSheet1");
            sht1.Cells[1,1].Value = "Occupation:";
            var validation = sht1.DataValidations.AddListValidation("A2");
            foreach(var allowedValue in GetAllowedValues())
            {
                validation.Formula.Values.Add(allowedValue);
            }
            excel.SaveAs(fInfo);
        }
    }
    private static IEnumerable<string> GetAllowedValues()
    {
        return new string []{"Doctor","Baker","Candlestick Maker"};
    } 
