    public class CustomersWrapper
    {
        public IEnumerable<CustomerWrapper> Customers { get; set; }
    }
    public class CustomerWrapper
    {
        public CustomerDto Customer { get; set; }
    }
