        public class MyDbContext : DbContext
        {
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                
                foreach (var type in QueryFilters.Filters.Keys)
                    foreach (var filter in QueryFilters.Filters[type])
                        modelBuilder.Entity(type).HasQueryFilter(filter);
            }
        }
