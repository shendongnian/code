        private static float _oldValue;
        private static void Ticker()
        {
            while (true)
            {
                const string uri = @"https://api.coinmarketcap.com/v1/ticker/ethereum/";
                var client = new WebClient();
                var content = client.DownloadString(uri);
                var results = JsonConvert.DeserializeObject<List<CoinApi>>(content);
                float currentAmount = results[0].price_usd;
                if (currentAmount < _oldValue)
                {
                    Console.WriteLine("Ammount is lower than the last time.");
                }
                else if (currentAmount > _oldValue)
                {
                    Console.WriteLine("The amount is higher than the last time.");
                }
                else if (currentAmount == _oldValue)
                {
                    Console.WriteLine("The amount hasnt changed since the last time we scanned.");
                }
                _oldValue = currentAmount;
            }
        }
