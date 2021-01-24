        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            ...
            modelBuilder.Properties<string>()
                    .Where(p => p.GetCustomAttributes(true).OfType<ColumnAttribute>().Any(a => a.TypeName.ToLowerInvariant() == "mediumtext"))
                    .Configure(p => p.HasColumnType("mediumtext"));
    
            modelBuilder.Properties<string>()
                    .Where(p => p.GetCustomAttributes(true).OfType<ColumnAttribute>().Any(a => a.TypeName.ToLowerInvariant() == "longtext"))
                    .Configure(p => p.HasColumnType("longtext"));
            ...
        }
