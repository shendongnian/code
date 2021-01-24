    public class Document1 : Document
    {
       public int WorkId {get; set;}
       public virtual Work Work {get; set;}
    }
    public MyDbContext : DbContext
    {
        public DbSet<Work> Works {get; set;}
        public DbSet<Document1> Document1s {get; set;}
        public DbSet<Document2> Document2s {get; set;}
        public DbSet<Document3> Document3s {get; set;}
    }
