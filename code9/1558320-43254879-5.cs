    public class ComponentContext: DbContext
    {
        public DbSet<FirstNameComponent> FirstNameComponents { get; set; }
        // Other mappings 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>()
                .Map<FirstNameComponent>(
                    configuration =>
                    configuration.Requires(Component.Discriminator).HasValue(FirstNameComponent.TypeOfComponent))
        }
    }
