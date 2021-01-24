    class LoginApiResponse
    {
        //.........
        [JsonProperty("userdetails")]
        public UserDetails[] UserDetails { get; set; }
        //                ^^
        // Alternatively, use List<UserDetails> instead of UserDetails[]
    }
