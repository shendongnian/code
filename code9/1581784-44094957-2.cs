        public class Customer
        {
            public string name { get; set; }
            public string type { get; set; }
        }
        public class CustomerWithComment
        {
            public string comment { get; set; }
            public Customer customer { get; set; }
        }
