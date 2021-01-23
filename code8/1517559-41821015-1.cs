    public class ProductAutoMappingOverride : IAutoMappingOverride<Product> {
        public void Override(AutoMapping<Product> mapping) {
           mapping.Id(p => p.ProductId),
           mapping.Map(p => p.ProductName),
           mapping.IgnoreProperty(p => p.BatchNumber);
           mapping.IgnoreProperty(p => p.StoreId);
        }
    
    }
