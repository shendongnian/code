    public class Customer
        {
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
            public Dictionary<string, string> Preferences { get; set; }
            public Customer()
            {
                Preferences = new Dictionary<string, string>();
            }
    
        }
