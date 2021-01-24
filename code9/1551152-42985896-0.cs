     public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public byte[] Content { get; set; } 
        public Guid ParentId { get; set; }
        public virtual EntityBase Parent { get; set; }
    }
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset CreationDate { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
    public class Customer : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class Product : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class MyCtx : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
    }
