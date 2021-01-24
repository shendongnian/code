    internal class CurrencyWrapper
        {
            public double MarketCap { get; private set; }
    
            public static CurrencyWrapper GetWrapper(string currencyCode, string jsonString)
            {
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                var instance = new CurrencyWrapper
                {
                    MarketCap = double.Parse(values["market_cap_" + currencyCode.ToLower()])
                };
                return instance;
            }
        }
