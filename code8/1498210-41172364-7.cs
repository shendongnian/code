    public class CarDBCtxt : DbContext
    {
        public DbSet<Samochody> Cars { get; set; }
    
        public CarDBCtx(): base("CarDBCtxt") 
        {
          Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDBCtxt>());  
        }
    }
