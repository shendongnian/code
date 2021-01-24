    class MyDBContext:DbContext
    {
        public MyDBContext()
            : base("mydbcontext")
        {
        }
        static MyDBContext()
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDBContext>());
    }
       
    public DbSet<CatalogType> CatalogTypes{ get; set; }
    public DbSet<Catalog> Catalogs{ get; set; }
    }
    public class CatalogType : AuditFields
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
                [Key]
        public string code { get; set; }
        public bool passive { get; set; }
        public ICollection<Catalog> Catalogs { get; set; }
    }
    public class Catalog : AuditFields
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public bool passive { get; set; }
        public int order { get; set; }
        public string typeCatalogRefCode { get; set; }
          [ForeignKey("typeCatalogRefCode")]
        public virtual CatalogType catalogType { get; set; }
    }
    public class AuditFields
    {
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public string createdIn { get; set; }
        public DateTime modifiedDate { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedIn { get; set; }
    }
