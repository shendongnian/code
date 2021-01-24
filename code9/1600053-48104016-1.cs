            string json = new WebClient().DownloadString("https://api.coinmarketcap.com/v1/ticker/");
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            foreach (var item in items)
            {
                Console.WriteLine("ID: " + item.id.ToUpper());
                Console.WriteLine("Name: " + item.name.ToUpper());
                Console.WriteLine("Symbol: " + item.symbol.ToUpper());
                Console.WriteLine("Rank: " + item.rank.ToUpper());
                Console.WriteLine("Price (USD): " + item.price_usd.ToUpper());
                Console.WriteLine("\n");
            }
        }
    }
