    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(p => p.Email).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("EmailIndex") { IsUnique = true }));
        }
