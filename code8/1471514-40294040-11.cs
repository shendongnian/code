    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new TesteContext();
            ctx.Database.CreateIfNotExists();
    
            Console.ReadKey();
        }
    }
    
    public class Parent
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
    
    public class Child
    {
        public int ChildId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
    
    public class TesteContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Childs { get; set; }
    
        public TesteContext() : base("Teste_123")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>()
                .HasRequired(x => x.Parent)
                .WithMany();
        }
    }
