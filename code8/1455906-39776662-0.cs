    public class NameValueStore : IValueStore
    {
        private readonly string _name;       
 
        public NameValueStore(string name)
        {
            _name = name;
        }
        public void AddValueToCustomer(Costumer costumer)
        {
            customer.Name = _name;
        }
    }
