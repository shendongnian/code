    class CustomerService
    {
        public ObservableCollectionOf<Customer> GetCustomers()
        {
             var customers=new CustomerRepository().GetCustomers().OrderBy...;
             return new ObservableCollectionOf(customers);
        }
    }
