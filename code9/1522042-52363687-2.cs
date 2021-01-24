        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .ToTable(typeof(File).Name + "s") // <-- the argument could be just "Files"
                .HasKey(lf => new { lf.MachineName, lf.PathName });
            base.OnModelCreating(modelBuilder);
        }
