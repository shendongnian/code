    public class UserInfo
    {
        [JsonProperty("AuthorId")]
        public string AuthorId { get; set; }
    }
    public class UserInfoResult
    {
        [JsonProperty("results")]
        public List<UserInfo> UserInfoCollection { get; set; }
    }
    public class UserInfoResultRoot
    {
        [JsonProperty("d")]
        public UserInfoResult Result { get; set; }
    }  
