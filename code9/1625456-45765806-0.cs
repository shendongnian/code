    public class jaykzoo
    {
        public class Address
        {
            public string street { get; set; }
            public string city { get; set; }
        }
        public class RootObject
        {
            public string name { get; set; }
            public List<Address> address { get; set; }
        }
    }
