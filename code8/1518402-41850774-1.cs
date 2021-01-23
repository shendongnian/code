    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Transaction>().HasKey(x => new { x.FromID, x.ToID });
    }
