    public class SubLoggerConfiguration
    {
    	public LogEventLevel Level { get; set; }
    
    	private string pathFormat;
    	public string PathFormat
    	{
    		get => pathFormat;
    		set => pathFormat = value.Replace("%APPLICATION_NAME%", Environment.GetEnvironmentVariable("APPLICATION_NAME"));
    	}
    }
