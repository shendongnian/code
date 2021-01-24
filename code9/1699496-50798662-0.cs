    public  class SomeDbContext: DbContext
    {
        // this PUBLIC constructor  is required for Migration tool
        public SomeDbContext()
        {
        
        }
      // the model...
        public DbSet<PocoBla> PocoBlas { get; set; }
        ....
     }
