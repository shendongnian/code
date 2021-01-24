    public class UserGroup
    {
        public string 11 { get; set; }
    }
    public class UserData {
        public string name  { get; set; }
        public string email  { get; set; }
        public string phone  { get; set; }
        public string current_group  { get; set; }
        public UserGroup user_groups  { get; set; }
    }
    public class ResponseObject
    {    
        public string msg { get; set; }
        public UserData data  { get; set; }
        public bool error  { get; set; }
    }
