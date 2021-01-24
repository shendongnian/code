    public class RootObject {
        public string nextRecords { get; set; }
        public IList<Customer> customers { get; set; }
    }
    
    public class Customer {
        public string name { get; set; }
    }
