    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            // one to one relationship between product and item
            HasOptional(p => p.Item).WithOptionalDependent(i => i.Product);
        }
    }
