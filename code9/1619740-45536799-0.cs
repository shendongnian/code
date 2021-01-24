    [JsonObject(MemberSerialization.OptIn)] // Only properties marked [JsonProperty] will be serialized
    public class Person : RealmObject
    {
        [JsonProperty]
        public string FirstName { get; set; }
        [JsonProperty]
        public string LastName { get; set; }
        [JsonProperty]
        public IList<Dog> Dogs { get; set; }
    }
