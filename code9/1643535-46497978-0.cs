    using (var parser = new ChoCSVReader("Dict1.csv")
        .WithField("AR_ID", 7)
        .WithField("AR_TYPE", 8)
        .WithFirstLineHeader(true)
        .Configure(c => c.IgnoreEmptyLine = true)
        )
    {
        var dict = parser.ToDictionary(item => item.AR_ID, item => item.AR_TYPE);
        foreach (var kvp in dict)
            Console.WriteLine(kvp.Key + " " + kvp.Value);
    }
