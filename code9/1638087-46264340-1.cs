    public class Rootobject
    {
        public Enumerations Enumerations { get; set; }
        public User[] Users { get; set; }
    }
    public class Enumerations
    {
        public Indiancity[] IndianCities { get; set; }
    }
    public class Indiancity
    {
        public string key { get; set; }
        public int val { get; set; }
    }
    public class User
    {
        public string AccessType { get; set; }
        public Male[] Male { get; set; }
        public Female[] Female { get; set; }
        public string Location { get; set; }
    }
    public class Male
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    public class Female
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
