    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Entity<BaseModel>().Map(m => {
            m.ToTable("BaseModel");
        });
        modelBuilder.Entity<AccountType>().Map(m => {
            m.MapInheritedProperties();
            m.ToTable("AccountType");
        });
    }
