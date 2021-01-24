    public class Employee
    {
        [XmlIgnore]
        public Address x;
        [XmlIgnore]
        public Contact  y;
        public string Address1 {
            get { return x == null ? null : x.Address1; }
            set { (x ?? (x = new Address()).Address1 = value; }
        }
        // note null handling in the above
        // TODO: the others
    }
