    public class CustomerRepository : IRepository<Customer>
    {
    	private readonly MyDbContext dbContext;
    
    	public CustomerRepository(MyDbContext dbContext)
    	{
    		this.dbContext = dbContext;
    	}
    
    	public IQueryable<Customer> Entities => InternalCustomersData.Concat(ExternalCustomersData).Select(CustomerSelector);
    
    	private IQueryable<Customer> InternalCustomers => InternalCustomersData.Select(CustomerSelector);
    
    	private IQueryable<Customer> ExternalCustomers => ExternalCustomersData.Select(CustomerSelector);
    
    	private IQueryable<CustomerData> InternalCustomersData =>
    		from customer in dbContext.InternalCustomers
    		select new CustomerData
    		{
    			Id = customer.Id,
    			Name = customer.Name,		
    			CompanyId = 1,
    			CompanyName = "Company",
    		};
    
    	private IQueryable<CustomerData> ExternalCustomersData =>
    		from customer in dbContext.ExternalCustomers
    		select new CustomerData
    		{
    			Id = customer.Id,
    			Name = customer.Name,		
    			CompanyId = customer.Company.Id,
    			CompanyName = customer.Company.Name,
    		};
    
    	private static readonly Expression<Func<CustomerData, Customer>> CustomerSelector = data => new Customer
    	{
    		Id = data.Id,
    		Name = data.Name,
    		Company = new Company
    		{
    			Id = data.CompanyId,
    			Name = data.CompanyName,
    		}
    	};
    
    	private class CustomerData
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public int CompanyId { get; set; }
    		public string CompanyName { get; set; }
    	}
    }
