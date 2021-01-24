    public List<Product> GetTopRelatedProducts(int N)
    {
    	var relatedSet = new HashSet<Product>();
    	var relatedListQueue = new Queue<List<Product>>();
    	if (RelatedProducts != null && RelatedProducts.Count > 0)
    		relatedListQueue.Enqueue(RelatedProducts);
    	while (relatedListQueue.Count > 0)
    	{
    		var relatedList = relatedListQueue.Dequeue();
    		foreach (var product in relatedList)
    		{
    			if (product != this && relatedSet.Add(product) && product.RelatedProducts != null && product.RelatedProducts.Count > 0)
    				relatedListQueue.Enqueue(product.RelatedProducts);
    		}
    	}
    	return relatedSet.OrderByDescending(x => x.Rating).Take(N).ToList();
    }
