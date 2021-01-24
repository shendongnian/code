    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public Manager Boss {get; set; }
    }
    
    [Serializable]
    public class Manager
    {
        public string Name { get; set; }
        
        [XmlIgnore]
        public User FavoriteEmployee {get; set; }
    }
