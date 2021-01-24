    using (var writer = new StreamWriter(@"C:\mypath\myfile.csv"))
    {
        var csv = new CsvWriter(writer);
        csv.Configuration.Delimiter = ",";
        foreach (var product in products)
        {
            foreach (var attribute in product.Attributes)
            {
                csv.WriteField(attribute.Value);
            }
            csv.NextRecord();
        }
    }
