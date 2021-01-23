    public class CountryValueStore : IValueStore
    {
        private readonly string _country;       
 
        public CountryNameValueStore(string country)
        {
            _country = country;
        }
        public void AddValueToCustomer(Costumer costumer)
        {
            customer.Country = _country;
        }
    }
