    public interface IAPICustomerRepository {
        IEnumerable<CustomerDto> GetCustomers(string query = null);
        CustomerDto GetCustomer(int id);
        int CreateCustomer(CustomerDto customerDto);
        CustomerDto UpdateCustomer(int id, CustomerDto customerDto);
        bool? DeleteCustomer(int id);
    }
