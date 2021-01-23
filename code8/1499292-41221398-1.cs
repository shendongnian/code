    public class person
    {
        public string gender {get; set;}
        public string age {get; set;}
        public string eyes {get; set;}
        public List<string> lastLogins {get; set;}
        public Dictionary<string, addressData> addresses {get; set;}
        public string hasPets {get; set;}
    }
    
    public class addressData
    {
        public string postCost {get; set;}
        public string streetAddress {get; set;}
        public string phoneNumber {get; set;}
    }
