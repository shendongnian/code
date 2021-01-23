    namespace WebApplication2
    {
        public class App2Context : BaseDbContext
        {
            public DbSet<City> Cities { get; set; }
        }
    
        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ApplicationUserId { get; set; }
            public ApplicationUser ApplicationUser { get; set; }
        }
    
    }
