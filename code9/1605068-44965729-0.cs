    public class RootObject
     {
        public string name { get; set; }
        public string tag { get; set; }
        public string description { get; set; }
        public string[] tags { get; set; }
        public Dictionary<string, Tag> tags { get; set; }
     }
    
     public Tag
     {
       public string name{ get; set; }
     }
    
