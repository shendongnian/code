    static void Main(string[] args)
    {
        string json = @"[130, 18063676, [[""i"", {
			""currencyPair"": ""XMR_BLK"",
			""orderBook"": [{
					""0.00229667"": ""22.10045806"",
					""0.00229668"": ""2.24052467"",
					""0.00230580"": ""0.66824024"",
					// ...
				}
			]
		}
		]]]";
        var outerArray = JArray.Parse(json);
        var innerNestedArray = outerArray[2];
        var iOrderBookArray = innerNestedArray[0];
        var orderBookElement = iOrderBookArray[1];
        var orderBook = orderBookElement.ToObject<OrderBook>();
        var orderLines = orderBook.orderBook[0].ToList();
    }
    public class OrderBook
    {
        public string currencyPair { get; set; }
        public Dictionary<string, string>[] orderBook { get; set; }
    }
