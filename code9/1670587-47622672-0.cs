    public class NewTableContext : DbContext
    {
        public DbSet<NewTable> NewTables{ get; set; }
        public NewTableContext() : base("DefaultConnection") { }
    }
