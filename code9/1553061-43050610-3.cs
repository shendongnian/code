    public List<Product> GetTopRelatedProducts(int N)
    {
    	var relatedSet = new HashSet<Product>();
    	GetRelatedProducts(this, relatedSet);
    	return relatedSet.OrderByDescending(x => x.Rating).Take(N).ToList();
    }
    
    private void GetRelatedProducts(Product product, HashSet<Product> relatedSet)
    {
    	if (product.RelatedProducts == null) return;
    	foreach (var item in product.RelatedProducts)
    		if (item != this && relatedSet.Add(item))
    			GetRelatedProducts(item, relatedSet);
    }
