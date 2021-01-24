    XmlSerializer serializer = new XmlSerializer(typeof(Response));
    var stringReader = new StringReader(thexml);
    Response response = (Response)serializer.Deserialize(stringReader);
    
    public class Response
    {
        public string IP { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string MetroCode { get; set; }
    }
