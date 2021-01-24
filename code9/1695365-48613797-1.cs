   	public class Ticker
	{
		public string cur { get; set; }
		public string symbol { get; set; }
		public double last { get; set; }
		public double high { get; set; }
		public double low { get; set; }
		public double volume { get; set; }
		public double vwap { get; set; }
		public double max_bid { get; set; }
		public double min_ask { get; set; }
		public double best_bid { get; set; }
		public double best_ask { get; set; }
	}
---
    var list = JsonConvert.DeserializeObject<List<Ticker>>(jsonstring);
