    public class CustomerFactory : ICustomerFactory
    {
        private readonly IClientFactory clientFactory;  //To be injected
        private readonly ConcurrentDictionary<int, ICustomer> customers = 
                     new ConcurrentDictionary<int, ICustomer>();
        public CustomerFactory(IClientFactory clientFactory)
        {
            this.clientFactory = clientFactory; //Injected
        }
        public ICustomer GetCustomer(int id)
        {
            ICustomer customer = this.customers.GetOrAdd(id, () => new Customer(id));
            if (customer.Client == null)
            {
                customer.Client = this.clientFactory.GetClient(customer.ClientID);
            }
            return customer;
        }
    }
