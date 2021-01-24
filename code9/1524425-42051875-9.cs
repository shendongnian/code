    public class Service
    {
    	public IList<Product> GetProducts(string currentUserRole)
    	{
    		// compare against Product's AllowedGroups
            return this.dataRepo.Products.Where(product => product.AllowedGroups.Contains(currentUserRole)).ToList();
    	}
    }
