    public class FoodDiaryContext:DbContext
        {
            public FoodDiaryContext()
            {
                this.Configuration.ProxyCreationEnabled = false;
            }
    
            public DbSet<Food> Foods { get; set; }
            public DbSet<Measure> Measures { get; set; }
        }
