    public interface IWorldContext
        {
            DbSet<Stop> Stops { get; set; }
            DbSet<Trip> Trips { get; set; }
        }
