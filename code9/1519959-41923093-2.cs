    public abstract class ConcurrencyTracker
    {
        [ConcurrencyCheck]
        public long LastChange { get; set; }
    
        [NotMapped]
        public DateTime LastChangeTime
        {
    	    set
    	    {
    		    long timestamp = value.Ticks - new DateTime(1970, 1, 1).Ticks;
    		    timestamp = timestamp / TimeSpan.TicksPerSecond;
    		    LastChange = timestamp;
    	    }
        }
    }
    public class Product : ConcurrencyTracker
    {
	    public int Id { get; set; }
     	public string Name { get; set; }
    }
