    public List<Product> GetProduct()
    {
    	List<Product> products = new List<Product>();
    	using (var ctx = new PosEntities())
    	{
    		var tempProducts = 
    			(from p in ctx.Products.Include("ProductPrimaryPrices").Include("ProductSecondaryPrices").Include("ProductsModifiers")
    			where (p.MenuGroupId == menuGroupId && p.Active) && (p.ProductPrimaryPrices.Any(x => x.OutletId == outletId && x.Active))
    			select new Product
                {
                    ProductId = p.ProductId,
                    Code = p.Code,
                    Name = p.Name,
                    Description = p.Description,                
                    ProductPrimaryPrices = p.ProductPrimaryPrices,
                    ProductSecondaryPrices = p.ProductSecondaryPrices,
                    ProductsModifiers = p.ProductsModifiers
                }).ToList();                    
    
    		foreach (object anonymous in tempProducts)
    		{
    			Product product = (Product)Utility.ToType<Product>(anonymous, new Product());
    			products.Add(product);
    		}
    		return products;
    	}
    }
