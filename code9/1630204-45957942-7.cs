    [JsonConverter(typeof(GithubPayloadConverter))]
    public class GithubPayload {
        public string Action { get; set; }
        public string Name { get; set; }
    }
