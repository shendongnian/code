    protected override void OnModelCreating(DbModelBuilder mb)
    {
        mb.Entity<UserAccount>()
            .HasMany(o1 => o1.Challenges)
            .WithOptional();
            .Map(m => m.MapKey("UserAccountId"));
    
        base.OnModelCreating(mb);
    }
