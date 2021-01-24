    using (var p = new ChoCSVReader<Site>("*** YOUR CSV FILE PATH ***")
        .WithFirstLineHeader(true)
        )
    {
        Exception ex;
        Console.WriteLine("IsValid: " + p.IsValid(out ex));
    }
