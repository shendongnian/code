	public class MetaData
	{
		public string Information { get; set; }
		public string Symbol { get; set; }
		public DateTime LastRefreshed { get; set; }
		public string Interval { get; set; }
		public string OutputSize { get; set; }
		public string TimeZone { get; set; }
	}
	public class TimeSeriesInfos
	{
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public double Volume { get; set; }
	}
	public class TimeSeries
	{
		public TimeSeriesInfos T1 { get; set; }
		public TimeSeriesInfos T2 { get; set; }
	}
	public class RootObject
	{
		public MetaData MetaData { get; set; }
		public TimeSeries TimeSeries { get; set; }
	}
