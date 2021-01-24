    using (var writer = new StreamWriter(new FileStream(@"C:\mypath\myfile.csv", FileMode.Append)))
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
