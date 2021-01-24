    public class CustomerValidation
    {
        public Customer Validate(int customerId)
        {
            // Validation logic which "produce" instance of customer by given id
            return customer;
        }
    }
    public class CustomerProcess
    {
        public Customer Process(Customer customer)
        {
            // Process given customer
        }
    }
    public class CustomerService
    {
        private CustomerValidation _validation;
        private CustomerProcess _process;
        public CustomerService(CustomerValidation validation, CustomerProcess process)
        {
            _validation = validation;
            _process = process;
        }
        public void DoStaff(int customerId)
        {
            var customer = _validation.Validate(customerId);
            if (customer != null)
            {
                _process.Process(customer);
            }
        }
    }
