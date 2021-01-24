    public class GithubPayload {
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonConverter(typeof(NestedConverter), "pull_request.title")]]
        public string Name { get; set; }
    }
