	public class CustomerService 
	{
		private ICortexBusinessManager _cortexBusinessManager;
		public CustomerService (ICortexBusinessManager cortexBusinessManager)
		{
			_cortexBusinessManager = cortexBusinessManager;
		}
		public List<CustomerViewModel> GetResellerCustomersWithProperties(string shortCode)
		{            
		    return _cortexBusinessManager.GetResellerCustomersWithProperties(shortCode); 
		}
	}
