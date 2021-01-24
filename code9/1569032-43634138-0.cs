    [JsonObject(MemberSerialization.OptIn)]
    public class Contact : RealmObject
    {
        [JsonProperty]
        public string birthdate { set; get; }
        [JsonProperty]
        public string city { set; get; }
        [JsonProperty]
        [PrimaryKey]
        public string contactId { set; get; }
        [JsonProperty]
        public string country { set; get; }
    }
