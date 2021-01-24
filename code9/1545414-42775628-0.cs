    class CustomerRepository
    {
        public IEnumerable<Customer> GetCustomers()
        {
             return yourContext.Customers.ToList();
        }
    }
