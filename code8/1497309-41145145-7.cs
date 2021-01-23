    public class Products
    {
        public ProductNameList Product { get; set; }
    }
    [CollectionDataContract(ItemName = "productName")]
    public class ProductNameList : List<string>
    {
    }    
