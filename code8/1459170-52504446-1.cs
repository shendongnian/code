    public class Schedule
    {
    	[JsonConverter(typeof(TimespanConverter))]
    	[JsonProperty(TypeNameHandling = TypeNameHandling.All)]
    	public TimeSpan Delay { get; set; }
    }
