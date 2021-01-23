    using System;
    
    public enum LogEntryType
    {
    	Event,
    	Message,
    	Warning,
    	Error
    }
    
    public class LogEntry
    {
    	public int? LogEntryID { get; set; }
    
    	public int? LogEntryType { get; set; }
    
    	public DateTime? EntryDate { get; set; }
    
    	public TimeSpan? ElapsedTime { get; set; }
    
    	public string Key { get; set; }
    
    	public string Description { get; set; }
    }
