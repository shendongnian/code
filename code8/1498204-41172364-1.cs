    public class CarDBCtxt : DbContext
    {
        public DbSet<Samochody> Cars { get; set; }
    
        public CarDbCtx()
        {
          Database.SetInitializer(new DropCreateDatabaseIfModelChanges());  
        }
    }
