    [JsonObject(MemberSerialization.OptIn)]
    public class Person
    {
        [JsonProperty]
        public string Name { get; set; }
           
        // not serialized because mode is opt-in
        public string Department { get; set; }
    }
