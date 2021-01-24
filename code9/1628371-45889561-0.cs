    public class CustomerFactory
    {
        private readonly lockObject = new object();
        private readonly IClientFactory clientFactory;  //To be injected
        private static ConcurrentDictionary<int, ICustomer> customers = 
                   new ConcurrentDictionary<int, ICustomer>();
        public CustomerFactory(IClientFactory clientFactory)
        {
            this.clientFactory = clientFactory; //Injected
        }
        public ICustomer GetCustomer(int id)
        {
            ICustomer customer;
            bool found = this.customers.TryGetValue(id, out customer);
            if (!found)
            {
                customer = new Customer(id);
                customers.TryAdd(id, customer);  //add to the cache before calling the ClientFactory
                customer.Client = this.clientFactory.GetClient(customer.ClientID);
            }
            return customer;
        }
    }
