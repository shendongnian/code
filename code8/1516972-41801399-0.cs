    public void UpdateCoinDict(CoinApi coin)
    {
        CoinDict[coin.Id] = coin;
    }
    public float GetCoinPrice(CoinApi coin)
    {
        if (CoinDict.Contains(coin.Id))
        {
            return CoinDict[coin.Id].price_usd;
        }
        else 
        {
            UpdateCoinDict(coin);
            return coin.price_usd;
        }              
    }
    private static void Ticker()
    {
        while (true)
        {
            const string uri = @"https://api.coinmarketcap.com/v1/ticker/ethereum/";
            var client = new WebClient();
            var content = client.DownloadString(uri);
            var results = JsonConvert.DeserializeObject<List<CoinApi>>(content);
            for (coin in results)
            {
                float currentAmount = coin.price_usd;
                float oldPrice = GetCoinPrice(coin); 
                if (currentAmount < oldPrice)
                {
                    Console.WriteLine("Ammount is lower than the last time.");
                }
                else if (currentAmount > oldPrice)
                {
                    Console.WriteLine("The amount is higher than the last time.");
                }
                else
                {
                Console.WriteLine("The amount hasnt changed since the last time we scanned.");
                }
            } 
        }
    }
