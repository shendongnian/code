    protected override void OnModelCreating(DbModelBuilder mb)
    {
        mb.Entity<UserAccount>()
            .HasMany(o1 => o1.Challenges)
            .WithOptional(e=>e.UserAccount);
            .HasForeignKey(e=>e.UserAccountId);
    
        base.OnModelCreating(mb);
    }
