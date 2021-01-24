      public AlmanacDb() { }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {           
           optionsBuilder.UseSqlServer(_connString);
      }
    
      private readonly string _connString = "<your conn string>";
