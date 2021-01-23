    class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseContext()
        {
            Database.SetInitializer<TContext>(null);
        }
    
        protected BaseContext() : base("Demo")
        {
    
        }
    }
    
    class UserContext : BaseContext<UserContext>
    {
        public DbSet<User> Users { get; set; }
    }
    
    class BuildingContext : BaseContext<BuildingContext>
    {
        public DbSet<Building> Buildings { get; set; }
    }
