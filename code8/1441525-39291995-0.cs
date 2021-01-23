    public class Product
    {
        public int ProductId { get; set; }
        public int StockCount { get; set; }
    }
    
    public class RootObject
    {
        public List<Product> Products { get; set; }
    }
    var jsonresult = JsonConvert.DeserializeObject<RootObject>(result);
