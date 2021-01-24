    public class ExtendedHttpClient : HttpClient
    {
        public ExtendedHttpClient(TokenHttpHandler messageHandler) : base(messageHandler)
        {
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        }
    }
