    public class Foo
    {
        [JsonProperty("user")]
        public User UserIdentity { get; set; }
        [JsonProperty("session")]
        public Session CurrentSession { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        string Id { get; set; }
    }
    public class Session
    {
        [JsonProperty("id")]
        string Id { get; set; }
    }
