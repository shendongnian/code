    public class AddedInfo
    {
        public int thisisinteresting { get; set; }
        public string id_str { get; set; }
    }
    
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public AddedInfo addedInfo { get; set; }
    }
