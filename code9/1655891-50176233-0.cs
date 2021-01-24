    "ConnectionStrings": {
    "MarkIdentity": "Server=(localdb)\\mssqllocaldb;Database=MarketIdentity;
     Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    services.AddDbContext<EfDbContext>(options =>
                
    options.UseSqlServer(Configuration.GetConnectionString("MarkIdentity")));
