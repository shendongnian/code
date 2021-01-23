    [DataContract]
    public class Packages
    {
        [DataMember]
        public string PackageID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public float BasePrice { get; set; }
        [DataMember]
        public List<string> Images { get; set; }
        [DataMember]
        public HotelInPackage Hotel { get; set; }
        [DataMember]
        public string TransportType { get; set; }
        public Packages(string packageID, string name, string destination, string description, int duration, float basePrice, List<string> images)
        {
            PackageID = packageID;
            Name = name;
            Destination = destination;
            Description = description;
            Duration = duration;
            BasePrice = basePrice;
            Images = images;
        }
    }
