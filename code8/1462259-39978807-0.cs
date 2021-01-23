    Product p1 = new Product
     {
      Name = "Product 1",
      Price = 99.95m,
      ExpiryDate = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc),
     };
    Product p2 = new Product
    {
     Name = "Product 2",
     Price = 12.50m,
     ExpiryDate = new DateTime(2009, 7, 31, 0, 0, 0, DateTimeKind.Utc),
    };
    ProductList productList = new ProductList ();
    p.Add(p1);
    p.Add(p2);
     
    string json = JsonConvert.SerializeObject(productList , Formatting.Indented);
    class ProductList 
    {
      Public List<Product> products{get;set;}
    }
