    public class Base
    {
    	[JsonProperty("years")]
    	public List<Year> years { get; set; }
    }
    	
    	public class Year
    	{
    		[JsonProperty("value")]
    		public int Value { get; set; }
    	
    		[JsonProperty("data")]
    		public List<Data> data { get; set; }
    	}
    
    	public class Data
    {
    		[JsonProperty("name")]
    	public string name { get; set; }
    		[JsonProperty("total")]
    		public decimal Total { get; set; }
    		[JsonProperty("Low")]
    		public decimal Low { get; set; }
    		[JsonProperty("Mid")]
    		public decimal Mid { get; set; }
    		[JsonProperty("High")]
    		public decimal High { get; set; }
    		[JsonProperty("min")]
    		public decimal Min { get; set; }
    		[JsonProperty("max")]
    		public decimal Max { get; set; }
    	}
