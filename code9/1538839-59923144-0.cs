public class Product{
    public int Id { get; set; }    
    public ObjectStatus Status { get; set; }
    // Foreign keys
    public int ProductNameId { get; set; }
    public virtual ProductName ProductName { get; set; }
    [NotMapped]
    public string Name => ProductName?.Name;    
}
public class ProductEntityConfiguration : EntityConfiguration<Product> {
    public ProductEntityConfiguration() {
        ToTable("Products");
        HasKey(p => p.Id);
        Property(p => p.Id).HasColumnName("Id");
        Property(p => p.Status).HasColumnName("Status");
        Property(p => p.ProductNameId).HasColumnName(@"ProductNameId").HasColumnType("int").IsRequired();
        HasRequired(a => a.ProductName).WithMany(b => b.Products).HasForeignKey(c => c.ProductNameId);
    }
}
This solution may 'look' complicated than the accepted answer because I am adding a foreign key here. But I bet most people already have these foreign keys anyway, so all you need to do is add the `NotMapped` property and you are done. It would be just a 1 line change.
