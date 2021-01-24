    public class DataContext : DbContext
        {
            public DbSet<DataStack1> DataStack1 { get; set; }
            public DbSet<DataStack2> DataStack2 { get; set; }
        }
