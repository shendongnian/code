    public class LogLevel
    {
    	public string Default { get; set; }
    }
    
    public class LoggerSettings
    {
    	public bool IncludeScopes { get; set; }
    
    	public LogLevel LogLevel { get; set; }
    }
