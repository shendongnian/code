    public List<string> GetProductsList()
    {
            List<string> productsList = new List<string>();
            using (Entities database = new Entities ())
            {
                productsList = (from product 
                                in database.Products
                                select product.ID).Take(10).ToList();
    
            }
            productsList = productsList.Select(str=>str.Replace(" ", "&nbsp;"));
            return productsList;
    }
