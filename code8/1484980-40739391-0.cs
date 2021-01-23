    public class InstagramProfile
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("bio")]
        public string Bio { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        ...
    }
