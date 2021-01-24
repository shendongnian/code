    public class Service
    {
    	public IList<Product> GetProducts(string currentUserRole)
    	{
    		// compare against Product's AllowedGroups
            return this.dataRepo.Products.Where(product => product.AllowedGroups.Contains(currentUserRole)).ToList();
    	}
        public Product GetProduct(int productId, string currentUserRole)
    	{
    		// compare against Product's AllowedGroups
            var product = this.dataRepo.Products.FirstOrDefault(product => product.Id == productId);
            if (!product.AllowedGroups.Contains(currentUserRole))
            {
              throw new AuthorizationException("{0} not allowed on {1}", currentUserRole, product.Name);
            }
    	}
    }
