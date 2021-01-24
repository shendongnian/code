    public class Specification
    {
        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public int? ParentSpecificationId { get; set; }
        public virtual Specification ParentSpecification { get; set; }
        public virtual ICollection<Specification> Children { get; } = new HashSet<Specification>();
    }
    public class Db : DbContext
    {
        public DbSet<Specification> Specifications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specification>()
                        .HasMany(s => s.Children)
                        .WithOptional(s => s.ParentSpecification)
                        .HasForeignKey(s => s.ParentSpecificationId)
                        .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
