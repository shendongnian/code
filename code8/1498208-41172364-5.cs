    public class CarDBCtxt : DbContext
    {
        public DbSet<Samochody> Cars { get; set; }
    
        public CarDbCtx(): base("CarDBCtxt") 
        {
          Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDBCtxt>());  
        }
    }
