	public class Name
    {
        [JsonProperty("first_lower")]
        public string first_lower { get; set; }
        [JsonProperty("first")]
        public string first { get; set; }
    }
    public class CharacterList
    {
        [JsonProperty("displayname")]
        public string displayname { get; set; }
        [JsonProperty("name")]
        public Name name { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
    }
    public class Character
    {
        [JsonProperty("character_list")]
        public List<CharacterList> character_list { get; set; }
    }
