    public class Customer
    {
        public int CustomerId {get; set; }
        public string CustomerName { get; set; }
        public string CustomerJson { get; set; }
    }
    
    public class CustomerTO
    {
        public int CustId { get; set; }
        public object CustData { get; set; }
        public object CustomerJson { get; set; }
    }
