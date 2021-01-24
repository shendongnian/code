       var products = new List<Product>
       {
            new Product { Name = "1" },
            new Product { Name = "4" },
            new Product { Name = "2" },
            new Product { Name = "5" }
       };
       var productList = products.OrderByName("DESC").ToList();
       var productList = products.OrderByName("ASC").ToList();
       public class Product
       {
          public string Name { get; set; }
       }
