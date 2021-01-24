    public class Result
    {
    	public string Coin { get; set; } //didn't bother here: changed property name to Coin
    	[JsonProperty("LP")]
    	public decimal LastPrice { get; set; }
    	[JsonProperty("PBV")]
    	public decimal PercentBuyVolume { get; set; }
    }
