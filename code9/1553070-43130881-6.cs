    public List<Product> GetTopRelatedProducts(int N)
    {
         List<Product> visitedProducts = new List<Product>();
         Queue<Product> ProductsQueue = new Queue<Product>();
         visitedProducts.add(this);
         foreach (product prod in relatedProducts)
             if(prod != this) //if a product can't be related to itself then remove this if statement
                 ProductsQueue.Enqueue(prod); 
         //for now visitedproducts contains only our main product and ProductsQueue contains the product related to it.
         
         while (ProductsQueue.count > 0)
         {
              Product p = ProductsQueue.Dequeue();
              visitedProducts.add(p);
              foreach (product prod in p.relatedProducts)
              {
                  if( ! visitedProduct.contains(prod) && !ProductsQueue.contains(prod))//if we haven't visited the product already or if it is not in the queue so we are going to visit it.
                      ProductsQueue.Enqueue(prod);
              }
       
         }
         //now visitedProducts contains all the products that are related (somehow :P) to your first product
   
         visitedProducts.remove(this);// to remove the main product from the results
         //all what is left to do is to take the top N products.
         return visitedProducts.OrderByDescending(x => x.Rating).Take(N).ToList();
    }
