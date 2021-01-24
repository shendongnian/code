        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UrlProvider>()
                .HasOne(p => p.Link)
                .WithOne(i => i.UrlProvider)
                .HasForeignKey<Link>(b => b.UrlProviderId);
        }
