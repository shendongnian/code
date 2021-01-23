    class Product
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
    
    List<Product> list1 = ...;
    List<Product> list2 = ...;
    var result = list1.Join(list2, new [] { "ProductName", "ProductCode" });
