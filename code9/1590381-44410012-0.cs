    public enum DocumentType
    {
        Document1,
        Document2,
        Document3,
    };
    public class Work
    {
        public int WorkId { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
    public class Document
    {
        public int DocumentId {get; set;} // primary key
        public DocumentType DocumentType {get; set;}
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
    public MyDbContext : DbContext
    {
        public DbSet<Work> Works {get; set;}
        public DbSet<Document> Documents {get; set;}
    }
