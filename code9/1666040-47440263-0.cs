    public class TypeA
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public Comment AddComment(string text)
        {
            var comment = new Comment { Id = Guid.NewGuid(), ParentId = Id, Type = Types.TypeA, Text = text };
            Comments.Add(comment);
            return comment;
        }
    }
    
    public class TypeB
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public Comment AddComment(string text)
        {
            var comment = new Comment { Id = Guid.NewGuid(), ParentId = Id, Type = Types.TypeB, Text = text };
            Comments.Add(comment);
            return comment;
        }
    }
    
    public enum Types
    {
        TypeA = 0,
        TypeB = 1
    }
    
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public Types Type { get; set; }
        public string Text { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<TypeA> TypeAs { get; set; }
        public DbSet<TypeB> TypeBs { get; set; }
    
        public MyContext() : base("Name=MyContext") { }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    
            modelBuilder.Entity<TypeA>()
                .HasKey(e => e.Id)
                .HasMany(e => e.Comments).WithMany();
    
            modelBuilder.Entity<TypeB>()
                .HasKey(e => e.Id)
                .HasMany(e => e.Comments).WithMany();
        }
    }
    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
    
    void Main()
    {   
        // helper code to use migrations, just for demo purposes
        var migrator = new DbMigrator(new Configuration());
        migrator.Update();
        //
        
        var db = new MyContext();
        var a = new TypeA { Id = Guid.NewGuid() };
        db.TypeAs.Add(a);
    
        var b = new TypeB { Id = Guid.NewGuid() };
        db.TypeBs.Add(b);
    
        db.SaveChanges();
    
        a.AddComment("A1 ");
        a.AddComment("A2");
        
        b.AddComment("B1");
        b.AddComment("B2");
        b.AddComment("B3");
        
        db.SaveChanges();
    
        var dba = db.TypeAs.Include(x => x.Comments).First(e => e.Id == a.Id);
        foreach (var c in dba.Comments)
        {
            Console.WriteLine("{0} {1} {2} {3}", c.Text, c.Id, c.ParentId, c.Type.ToString());
        }
    }
