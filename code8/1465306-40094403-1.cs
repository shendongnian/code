    class RootObject
    {
        [JsonProperty("users")]
        public Users Users { get; set; }
    }
    [JsonConverter(typeof(TypedExtensionDataConverter<Users>))]
    class Users
    {
        public Users()
        {
            this.UserTable = new Dictionary<string, User>();
        }
        [JsonProperty("parentname")]
        public string ParentName { get; set; }
        [JsonTypedExtensionData]
        public Dictionary<string, User> UserTable { get; set; }
    }
    class User
    {
        public string name { get; set; }
        public string state { get; set; }
        public string id { get; set; }
    }
