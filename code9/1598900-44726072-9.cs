    using (TextWriter writer = new StreamWriter(@"C:\test.csv"))
    {
        var csv = new CsvWriter(writer);
        csv.Configuration.Encoding = Encoding.UTF8;
        csv.WriteRecords(products.SelectMany(product => product.Attributes)); 
    }
