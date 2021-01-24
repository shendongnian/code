     public class KeycloakTokenResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_type", Required = Required.Default)]
        public string TokenType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expires_in", Required = Required.Default)]
        public int ExpiresIn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refresh_expires_in", Required = Required.Default)]
        public int RefreshExpiresIn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "not-before-policy", Required = Required.Default)]
        public string NotBeforePolicy { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "access_token", Required = Required.Default)]
        public string AccessToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refresh_token", Required = Required.Default)]
        public string RefreshToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id_token", Required = Required.Default)]
        public string IdToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "session_state", Required = Required.Default)]
        public string SessionState { get; set; }
    }
