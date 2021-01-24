    JsonConvert.DeserializeObject<RootObject>(jsonString);
    public class Asdf
    {
        public bool read { get; set; }
        public bool write { get; set; }
    }
    
    public class RoleAdmin
    {
        public bool read { get; set; }
    }
    
    public class ACL
    {
        public Asdf asdf { get; set; }
        public RoleAdmin { get; set; }
    }
    
    public class Result
    {
        public ACL ACL { get; set; }
        public string REID { get; set; }
        public string createdAt { get; set; }
        public string email { get; set; }
        public string objectId { get; set; }
        public string updatedAt { get; set; }
        public int urlCount { get; set; }
        public List<string> urlList { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
