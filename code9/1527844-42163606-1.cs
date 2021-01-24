	public class CustomerRepository
	{
		public CustomerRepository(IQueryable<Customer> customers, IQueryable<OtherEntity> otherEntities)
		{			
            _customers = customers;
            _otherEntities = otherEntities;
		}
		
		public IQueryable<TCustomer> FilterByCustomer(int customerId) 
		{
			var customer = _customers.Where(...);
			
			var anotherEntity = _otherEntities.Where(...);
		}
	}
