    public class LoggingLevel
    {
    	public string Default { get; set; }
    }
    
    public class LoggerSettings
    {
    	public bool IncludeScopes { get; set; }
    
    	public LoggingLevel LogLevel { get; set; }
    }
