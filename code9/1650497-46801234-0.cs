    bool isValid = true;
    using (var cr = new ChoCSVReader("sample.csv")
        .WithFirstLineHeader()
        .WithField("firstName")
        .WithField("lastName")
        .WithField("salary", fieldType: typeof(double))
        .Setup(c => c.RecordLoadError += (o, e) => { isValid = false; e.Handled = true; })
        .Configure(c => c.ErrorMode = ChoErrorMode.ReportAndContinue)
    )
    {
        foreach (var x in cr)
            Console.WriteLine(ChoUtility.ToStringEx(x));
    }
    Console.WriteLine(isValid);
