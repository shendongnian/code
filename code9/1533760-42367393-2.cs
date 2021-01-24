    public class Program
    {
        static void Main(string[] args)
        {
            var config = AppMapper.Mapping();
            var mapper = config.CreateMapper();
            
            // From Previous question get list of Customer objects
            var customers = AddCustomers();
            var mappedCustomers = mapper.Map<IEnumerable<CustomerTO>>(customers);
        }
    }
