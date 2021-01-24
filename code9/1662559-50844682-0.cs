    public partial class ItemConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Item>
    {
        partial void InitializePartial()
        {
            HasOptional(a => a.ItemVendor).WithMany().HasForeignKey(a => a.VendorNumber).WillCascadeOnDelete(false); 
        }
    }
