    public List<Product> GetTopRelatedProducts(int N)
    {
    	var relatedSet = new HashSet<Product>();
    	GetRelatedProducts(this);
    	return relatedSet.OrderByDescending(x => x.Rating).Take(N).ToList();
    
    	void GetRelatedProducts(Product product)
    	{
    		if (product.RelatedProducts == null) return;
    		foreach (var item in product.RelatedProducts)
    			if (item != this && relatedSet.Add(item))
    				GetRelatedProducts(item);
    	}
    }
