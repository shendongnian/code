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
    
    	public virtual Airplane Airplane { get; private set; }
        // ... other properties
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<FlightPlan>()
           .HasRequired(flightPlan => flightPlan.Airplane)
           .WithOptional(airplane => airplane.FlightPlan);
    
           base.OnModelCreating(modelBuilder);
    }
