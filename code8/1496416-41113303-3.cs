    public class FBModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Events Events { get; set; }
        public override string ToString()
        {
            return ID + ": " + Name;
        }
    }
    public class Events
    {
        public List<Data> Data { get; set; }
    }
   
     public class Data
    {
        public string Description { get; set; }
        public string End_Time { get; set; }
        public string Name { get; set; }
        public Place Place { get; set; }
        public string Start_Time { get; set; }
        public string Id { get; set; }
    }
    public class Place
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }
    public class Location
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
