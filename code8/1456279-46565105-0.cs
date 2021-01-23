    public class HttpRequestMessage : IDisposable
    {
        [... ctors]
        public Version Version { get; set; }
        public HttpContent Content { get; set; }
        public HttpMethod Method { get; set; }
        public Uri RequestUri { get; set; }
        public HttpRequestHeaders Headers { get; }
        public IDictionary<string, object> Properties { get; }
        [... Dispose, ToString]
    }
