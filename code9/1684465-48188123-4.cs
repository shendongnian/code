     public IEnumerable<Coin> GetCoins(string json)
     {
            var jObject = JObject.Parse(json);
            var coinPropery = jObject["Coins"] as JArray;
            var coins = new List<Coin>();
            foreach (var property in coinPropery)
            {
                var propertyList = JsonConvert.DeserializeObject<List<Coin>>(property.ToString());
                coins.AddRange(propertyList);
            }
            return coins;
     }
