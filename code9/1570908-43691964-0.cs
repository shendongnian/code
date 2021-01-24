    Console.WriteLine($"{currencyRates.Disclaimer}");
    Console.WriteLine($"{currencyRates.License}");
    Console.WriteLine($"{currencyRates.TimeStamp}");
    Console.WriteLine($"{currencyRates.Base}");
    foreach (var currencyRatesRate in currencyRates.Rates)
    {
        Console.WriteLine($"Key: {currencyRatesRate.Key}, Value: {currencyRatesRate.Value}");
    }
