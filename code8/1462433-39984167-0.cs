    public class Packages
    {
        public string PackageID { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float BasePrice { get; set; }
        public List<string> Images { get; set; }
        public HotelInPackage Hotel { get; set; }
        public string TransportType { get; set; }
        Packages()
        {
            Debug.WriteLine("Calling private constructor of " + GetType().FullName);
        }
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
