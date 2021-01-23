    public class Rootobject
        {
            public Questions Questions { get; set; }
        }
    
        public class Questions
        {
            public string id { get; set; }
            public string BOOK { get; set; }
            public Students students { get; set; }
            public Locations locations { get; set; }
        }
    
        public class Students
        {
            public string _class { get; set; }
            public string theme { get; set; }
            public string _43 { get; set; }
        }
    
        public class Locations
        {
            public string h { get; set; }
            public string L { get; set; }
        }
