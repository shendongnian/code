    static string RevisedConversionFunction(string input, string from, string to)
    {
        Dictionary<string, decimal> dExchange = new Dictionary<string, decimal>()
        { 
            {"USD" , 1},
            {"AUD" , 1.31m},
            {"CAD" , 1.28m},
            {"EUR" , 0.95m},
            {"GBP" , 0.68m},
            {"NZD" , 1.36m}
        };
        if (dExchange.ContainsKey(from) && dExchange.ContainsKey(to))
        {
            return Math.Round((decimal.Parse(input) / dExchange[from]) * dExchange[to], 2).ToString();
        }
        else
        {
            // at least one currency not in the dictionary - exception handling?
            return null; 
        }
    }
