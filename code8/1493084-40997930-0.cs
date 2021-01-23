    public class RootObject
    {
        public List<Event> events { get; set; }
        public Metadata metadata { get; set; }
    }
    public class Stats
    {
        public int attending { get; set; }
        public int declined { get; set; }
        public int maybe { get; set; }
        public int noreply { get; set; }
    }
    
    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
    }
    
    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public string coverPicture { get; set; }
        public string profilePicture { get; set; }
        public Location location { get; set; }
    }
    
    public class Event
    {
        public string id { get; set; }
        public string name { get; set; }
        public string coverPicture { get; set; }
        public string profilePicture { get; set; }
        public string description { get; set; }
        public string distance { get; set; }
        public string startTime { get; set; }
        public int timeFromNow { get; set; }
        public Stats stats { get; set; }
        public Venue venue { get; set; }
    }
    
    public class Metadata
    {
        public int venues { get; set; }
        public int venuesWithEvents { get; set; }
        public int events { get; set; }
    }
    
