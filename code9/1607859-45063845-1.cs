    namespace MyClientAPI
    {
        public class MyClient
        {
            private readonly string _baseAddress;
            public MyClient(string baseAddress)
            {
                _baseAddress = baseAddress;
            }
            public List<Customer> GetCustomers()
            {
                var restClient= new RestClient(_baseAddress);
                var request = new RestRequest("customers/all");
                var customers = restClient.Execute<List<Customer>>(request);
                return Customers;
            }
        }
    }
