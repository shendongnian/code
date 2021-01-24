	public class MetaData
	{
		[JsonProperty("1. Information")]
		public string Information { get; set; }
		[JsonProperty("2. Symbol")]
		public string Symbol { get; set; }
		[JsonProperty("3. Last Refreshed")]
		public string LastRefreshed { get; set; }
		[JsonProperty("4. Interval")]
		public string Interval { get; set; }
		[JsonProperty("5. Output Size")]
		public string OutputSize { get; set; }
		[JsonProperty("6. Time Zone")]
		public string TimeZone { get; set; }
	}
	public class T1
	{
		[JsonProperty("1. Information")]
		public string Open { get; set; }
		[JsonProperty("2. high")]
		public string High { get; set; }
		[JsonProperty("3. low")]
		public string Low { get; set; }
		[JsonProperty("4. close")]
		public string Close { get; set; }
		[JsonProperty("5. volume")]
		public string Volume { get; set; }
	}
	public class T2
	{
		[JsonProperty("1. Information")]
		public string Open { get; set; }
		[JsonProperty("2. high")]
		public string High { get; set; }
		[JsonProperty("3. low")]
		public string Low { get; set; }
		[JsonProperty("4. close")]
		public string Close { get; set; }
		[JsonProperty("5. volume")]
		public string Volume { get; set; }
	}
	public class TimeSeries
	{
		[JsonProperty("2017-05-30 16:00:00")]
		public T1 T1 { get; set; }
		[JsonProperty("2017-05-30 15:59:00")]
		public T2 T2 { get; set; }
	}
	public class RootObject
	{
		[JsonProperty("Meta Data")]
		public MetaData MetaData { get; set; }
		[JsonProperty("Time Series (1min)")]
		public TimeSeries TimeSeries { get; set; }
	}
