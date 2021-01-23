    internal class reCaptchaResponse
    {
        [JsonProperty]
        internal bool success { get; set; }
        [JsonProperty]
        internal DateTime challenge_ts { get; set; }  // timestamp of the challenge load (ISO format yyyy-MM-dd'T'HH:mm:ssZZ)
        [JsonProperty]
        internal string hostname { get; set; }        // the hostname of the site where the reCAPTCHA was solved
        [JsonProperty]
        internal string[] error_codes { get; set; }   // optional
    }
