    class ResponseCall
    {
        [JsonProperty("responseHeader")]
        public ResponseHeader ResponseHeader { get; set; }
        [JsonProperty("response")]
        public Response Response { get; set; }
        [JsonProperty("highlighting")]
        public Dictionary<string, object> Highlighting { get; set; }
    }
    class ResponseHeader
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("QTime")]
        public int QTime { get; set; }
        [JsonProperty("params")]
        public Dictionary<string, string> Params { get; set; }
    }
    class Response
    {
        [JsonProperty("numFound")]
        public int NumFound { get; set; }
        [JsonProperty("start")]
        public int Start { get; set; }
        [JsonProperty("docs")]
        public List<Dictionary<string, string>> Docs { get; set; }
    }
