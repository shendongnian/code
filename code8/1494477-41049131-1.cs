    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Preference> Preferences { get; set;}
    }
    
    public class Preference
    {
        public string Preference { get; set; }
        public string PreferenceValue { get; set; }
    }
