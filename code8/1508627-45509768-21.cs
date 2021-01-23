    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AzureAdTokenResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "token_type", Required = Required.Default)]
        public string TokenType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expires_in", Required = Required.Default)]
        public int ExpiresIn { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expires_on", Required = Required.Default)]
        public string ExpiresOn { get; set; } 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "resource", Required = Required.Default)]
        public string Resource { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "access_token", Required = Required.Default)]
        public string AccessToken { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refresh_token", Required = Required.Default)]
        public string RefreshToken { get; set; }
    }
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AzureAdErrorResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error", Required = Required.Default)]
        public string Error { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error_description", Required = Required.Default)]
        public string ErrorDescription { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error_codes", Required = Required.Default)]
        public int[] ErrorCodes { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "timestamp", Required = Required.Default)]
        public string Timestamp { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "trace_id", Required = Required.Default)]
        public string TraceId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "correlation_id", Required = Required.Default)]
        public string CorrelationId { get; set; }
    }
    public class AzureAdTokenApiException : Exception
    {
        public AzureAdErrorResponse Error { get; }
        public AzureAdTokenApiException(AzureAdErrorResponse error) :
            base($"{error.Error} {error.ErrorDescription}")
        {
            Error = error;
        }
    }
