    static string RevisedConversionFunction(string input, string from, string to)
    {
        decimal fromExchangeRate = 0, toExchangeRate = 0;
        Dictionary<string, decimal> dExchange = new Dictionary<string, decimal>()
        { 
            {"USD" , 1},
            {"AUD" , 1.31m},
            {"CAD" , 1.28m},
            {"EUR" , 0.95m},
            {"GBP" , 0.68m},
            {"NZD" , 1.36m}
        };
        if (dExchange.ContainsKey(from))
        {
            fromExchangeRate = dExchange[from];
        }
        if (dExchange.ContainsKey(to))
        {
            toExchangeRate = dExchange[to];
        }
        return Math.Round((decimal.Parse(input) / fromExchangeRate) * toExchangeRate, 2).ToString();
    }
