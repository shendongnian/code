    ProductDetails [] items1= { new ProductDetails { description= "aa", id= 9, rating=2.0f }, 
                           new ProductDetails { description= "b", id= 4, rating=2.0f} };
    
    ProductDetails [] items= { new ProductDetails { description= "aa", id= 9, rating=1.0f }, 
                           new ProductDetails { description= "c", id= 12, rating=2.0f } };
    IEnumerable<ProductDetails> duplicates =
        items1.Intersect(items2, new ProductComparer());
    
       
