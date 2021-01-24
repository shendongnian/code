    class LoginApiResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("userdetails")]
        public UserDetails UserDetails { get; set; }
    }
