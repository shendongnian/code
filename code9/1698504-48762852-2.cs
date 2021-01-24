    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    List<Product> productList = new List<Product>();
    productList.Add(new Product() { Name = "Car", Price = 140000 });
    productList.Add(new Product() { Name = "SSD Disc", Price = 2000 });
    productList.Add(new Product() { Name = "Bananan", Price = 7 });
