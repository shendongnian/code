    [JsonObject(MemberSerialization.OptIn)]
    public class User {
        public User(string code) {
            this.Code = code;
        }
        [JsonProperty]
        public string Code { get; set; }
        private List<UserGroup> groups;
        [JsonProperty("Groups", ItemConverterType = typeof(UserGroupJsonConverter))]
        public List<UserGroup> Groups {
            get {
                if (groups == null)
                    groups = new List<UserGroup>();
                return groups;
            }
        }
    }
