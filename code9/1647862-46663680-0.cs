    public class Rootobject
    {
        public Inforesponse infoResponse { get; set; }
    }
    public class Inforesponse
    {
        public Servicepoint[] servicePoints { get; set; }
    }
    public class Servicepoint
    {
        public string servicePointId { get; set; }
        public string name { get; set; }
        public Deliveryaddress deliveryAddress { get; set; }
        public Dictionary<string, string>[] openingHours { get; set; }
    }
    public class Deliveryaddress
    {
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
    }
