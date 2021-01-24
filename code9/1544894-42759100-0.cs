    List<Product> allProducts = new List<Product>();
    
    List<string> productlines = File.ReadAllLines("Product.txt").ToList();
    
    //Remove headers
    productlines.RemoveAt(0);
    
    foreach(string line in productlines)
    {
         string[] parts = line.Split(';');
    
         Product product = new Product();
         product.Name = parts[0];
         product.Price = Convert.ToInt32(parts[1]);
         product.Quantity = Convert.ToInt32(parts[2]);
    
         allProducts.Add(product);
    }
