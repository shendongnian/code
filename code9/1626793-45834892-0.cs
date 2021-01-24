    Dictionary<string, double> _prices = new Dictionary<string, double>();
    GetPrices()
        .Buffer(TimeSpan.FromSeconds(1))
        .Subscribe(prices =>
        {
            if (prices != null && prices.Count > 0)
            {
                var grouped = prices.GroupBy(x => x.Key);
                foreach (var group in grouped)
                    _prices[group.Key] = group.Last().Bid;
            }
            //print out the last quote of each known price key
            foreach (var price in _prices)
            {
                Console.WriteLine("Key: " + price.Key + ", last price: " + price.Value);
            }
        });
