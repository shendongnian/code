    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                
                // Set default precision to decimal property
                foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                {
                    property.SetColumnType("decimal(18, 2)");
                }
            }
