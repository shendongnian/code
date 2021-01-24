    public class FindCustomer : IDataQuery<Customer>
    {
        public string CustomerNumber { get; set; }
    }
	public class FindCustomerHandler : IQueryHandler<FindCustomer, Customer>
    {
        private readonly DbContext context;
        public FindCustomerHandler(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }
        public Customer Handle(GetCustomer query)
        {
            return (from customer in context.Customers
                    where customer.CustomerNumber == query.CustomerNumber
                    select new Customer
                    {
                        Id = customer.Id,
                        Name = customer.Name,
                        Addresses = customer.Addresses.Select(a =>
                            new Address
                            {
                                Id = a.Id,
                                Line1 = a.Line1,
                                Line2 = a.Line2,
								Line3 = a.Line3
                            })
                            .OrderBy(x => x.Id)
                    }).FirstOrDefault(); 
        }
    }
