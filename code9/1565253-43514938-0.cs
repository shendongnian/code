    public AlmanacDb Create()
    {
         var optionsBuilder = new DbContextOptionsBuilder<AlmanacDb>();
         optionsBuilder.UseSqlServer(connectionString);
    
         return new AlmanacDb(optionsBuilder.Options);
    }
