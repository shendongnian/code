    public class CustomerOrders
    {
        public static IEnumerable<Customer> GetCustomer() 
        {
            Customer cu = new Customer();
            cu.CustomerData();
            // from r in cu.ListCustomer select r
            return cu.ListCustomer; //no need to use LinQ here
        }
    }
