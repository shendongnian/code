        public class Requirement
        {
            public string Id { get; set; }
            public string desc { get; set; }
        }
        
        public class Requirements
        {
            public List<Requirement> requirement { get; set; }
        }
        
        public class RootObject
        {
            public Requirements requirements { get; set; }
        }
    
    
     var x =JsonConvert.DeserializeObject<RootObject>(json);
