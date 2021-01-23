    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Preferences Preferences { get; set;}
    }
    
    public class Preferences 
    {
        public string Preference { get; set; }
        public string PreferenceValue { get; set; }
    }
