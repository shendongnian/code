    public class LogEntryModel
    {
    	public string Message { get; set; }
    
    	public DateTimeOffset Timestamp { get; set; }
    }
    
    public class PercolatedQuery
    {
    	public string Id { get; set; }
    
    	public QueryContainer Query { get; set; }
    }
