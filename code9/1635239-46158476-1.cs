    public class ProductsRetailers
    {
        [ForeignKey(typeof(Product))]
        public int ProductID { get; set; }
        [ForeignKey(typeof(Retailer))]
        public int RetailerID { get; set; }
    }
