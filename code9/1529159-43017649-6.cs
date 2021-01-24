    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(t => t.CategoryID);
            ToTable("Categories");
            Property(t => t.CategoryID).HasColumnName("CategoryID");
        }
    }
    public class SubtypeMap : EntityTypeConfiguration<Subtype>
    {
        public SubtypeMap()
        {
            HasKey(t => t.Id);
            Property(t => t.SupplierID).HasColumnName("SupplierID");
            HasOptional(t => t.Supplier)
                .WithMany(t => t.Subtypes)
                .HasForeignKey(d => d.SupplierID);
        }
    }
