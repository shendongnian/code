        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BbUser>(b => b.ToTable("AspNetUsers"));
            base.OnModelCreating(builder);
        }
