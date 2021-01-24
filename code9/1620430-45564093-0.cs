	public class ExchangeRate
	{
		[Key]
		public long ExhangeRateId { get; set; }
		public double HighestBid { get; set; }
		public double LowestAsk { get; set; }
		public double Volume { get; set; }
		public double Last { get; set; }
		public DateTime UpdateTime { get; set; }
		public long CurrencyPairId { get; set; }
		public virtual CurrencyPair CurrencyPair { get; set; }
	}
