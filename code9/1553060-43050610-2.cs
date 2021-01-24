    public List<Product> GetTopRelatedProducts(int N)
    {
    	if (RelatedProducts == null || RelatedProducts.Count == 0)
    		return new List<Product>();
    	var relatedSet = new HashSet<Product>();
    	var pendingStack = new Stack<List<Product>.Enumerator>();
    	var relatedList = RelatedProducts.GetEnumerator(); 
    	while (true)
    	{
    		while (relatedList.MoveNext())
    		{
    			var product = relatedList.Current;
    			if (product != this && relatedSet.Add(product) && product.RelatedProducts != null && product.RelatedProducts.Count > 0)
    			{
    				pendingStack.Push(relatedList);
    				relatedList = product.RelatedProducts.GetEnumerator();
    			}
    		}
    		if (pendingStack.Count == 0) break;
    		relatedList = pendingStack.Pop();
    	} 
    	return relatedSet.OrderByDescending(x => x.Rating).Take(N).ToList();
    }
