    public class User
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
    public class Session
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
    public class MyJson 
    {
        [JsonProperty("user")]
        private User user { get; set; }
        [JsonProperty("session")]
        private Session session { get; set; }     
        public string UserID { get { return user.id; }  } 
        public string SessionID { get { return session.id; } }
    }
