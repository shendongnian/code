    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [DefaultValue("")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
