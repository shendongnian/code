    using System.Data.Entity;
    public class Context : DbContext
    {
        public DbSet<Local> Locals { get; set; }
        public Context() : base("ConnectionStringKeyName") { }
    }
