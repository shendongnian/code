    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<CountryBusiness>().HasKey(cb => new {cb.CountryId, cb.BusinessId});
    }
