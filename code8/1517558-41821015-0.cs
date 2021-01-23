    public class ProductAutoMappingOverride : IAutoMappingOverride<Product> {
        public void Override(AutoMapping<Product> mapping) {
           mapping.IgnoreProperty(p => p.BatchNumber);
           mapping.IgnoreProperty(p => p.StoreId);
        }
    
    }
