    public partial class EntitiesMs : DbContext
    {
        public EntitiesMs()
            : base("name=EntitiesMs")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        // Your DbSet<...> Stuff
    }
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        // Your DbSet<...> Stuff
    }
