    public class Product
    {
        [AutoIncrement]
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateCreated { get; set; }
        [Reference]
        public List<StockItem> StockItems { get; set; }
    }
    public class StockItem
    {
        [AutoIncrement]
        public int Id { get; set; }
        [References(typeof(Product))]
        public int ProductId { get; set; }
        public string Size { get; set; }
        public int TotalStockQuantity { get; set; }
        public string Gtin { get; set; }
        public int DisplayOrder { get; set; }
    }
