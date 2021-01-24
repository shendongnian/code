    public class User : ILoadable
    {
        public User(string code)
        {
            this.Load(code);
        }
        public string Code { get; set; }
        [JsonConverter(typeof(StringObjectConverter))]
        public UserGroup Group { get; set; }
    }
