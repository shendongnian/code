    public class Airplane
    {
        [Key]
        public int Id { get; private set; }
    
        public virtual FlightPlan FlightPlan { get; private set; }
        // ... other properties
    }
    
    public class FlightPlan
    {
    	[Key]
    	public int Id { get; private set; }
    
    	[ForeignKey("AirplaneId")]
    	public virtual Airplane Airplane { get; private set; }
    
    	[Required]
    	public int AirplaneId { get; private set; }
        // ... other properties
    }
