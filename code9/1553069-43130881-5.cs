    public List<Product> GetTopRelatedProducts(int N)
    {
    List<Product> visitedProducts = new List<Product>();
    Queue<Product> ProductsQueue = new Queue<Product>();
    visitedProducts.add(this);
    foreach (product prod in relatedProducts)
         ProductsQueue.Enqueue(prod); 
    while (ProductsQueue.count > 0)
    {
       Product p = ProductsQueue.Dequeue();
       visitedProducts.add(p);
       foreach (product prod in p.relatedProducts)
       {
           if( ! visitedProduct.contains(prod) && !ProductsQueue.contains(prod))
               ProductsQueue.Enqueue(prod);
       }
       
    }
   
    visitedProducts.remove(this);
    
    return visitedProducts.OrderByDescending(x => x.Rating).Take(N).ToList();
    }
