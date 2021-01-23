    public class MyContext : DbContext
    {
        public MyContext() : base("DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasMany(c => c.InvoicesFrom).WithRequired(i => i.FromCompany).WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasMany(c => c.InvoicesTo).WithRequired(i => i.ToCompany).WillCascadeOnDelete(false);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public virtual ICollection<Invoice> InvoicesFrom { get; set; }
        public virtual ICollection<Invoice> InvoicesTo { get; set; }
        [NotMapped]
        public IEnumerable<Invoice> Invoices
        {
            get {
                return InvoicesFrom.Concat(InvoicesTo);
            }
        }
    }
    public class Invoice
    {
        public int Id { get; set; }
        public int FromCompanyId { get; set; }
        public int ToCompanyId { get; set; }
        public virtual Company FromCompany { get; set; }
        public virtual Company ToCompany { get; set; }
    }
