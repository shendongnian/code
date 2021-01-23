        public class Country
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
    
        }
    
        public class ConuntryContext : DbContext
        {
            public virtual DbSet<Country> Country { get; set; }
        }
