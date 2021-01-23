    public class CustomerManager
    {
        private IDataService _service;
        // You can pass here any implementation you want
        public CustomerFactory(IDataService service)
        {
            _service = service;
        }
        // This method now can be tested 
        // without dependencies on implementation details of data service
        public bool Remove(Customer customer)
        {
            if (customer.CanBeRemoved == true)
            {
                _service.RemoveCustomer(customer.Id);
                return true;
            }
   
            return false;
        }
    }
