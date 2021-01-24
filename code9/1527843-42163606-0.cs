	public class CustomerRepository<TCustomer>
		where TCustomer : class, ICustomerEntity
	{
		public CustomerRepository(IYourContext context)
		{
			_context = context;
		}
		
		public IQueryable<TCustomer> FilterByCustomer(int customerId) 
		{
			var customer = _context.Customers.Where(...);
			
			var anotherEntity = _context.OtherEntities.Where(...);
		}
	}
