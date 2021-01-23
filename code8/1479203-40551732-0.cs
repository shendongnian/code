    class TwitterName
    {
        public string first { get; set; }
        public string last { get; set; }
    }
    
    class TwitterUser
    {
        public TwitterName name { get; set; }
    }
    
    class TwitterUsers
    {
        public TwitterUser[] results { get; set; }
    }
    var jss = new JavaScriptSerializer();
    var users = jss.Deserialize<TwitterUsers>(jsonString);
