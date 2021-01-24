    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _fakeResponses = new Dictionary<Uri, HttpResponseMessage>();
        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage, string content = "", bool asXml = false)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                if (asXml)
                {
                    responseMessage.Content = new StringContent(content, Encoding.UTF8, "application/xml");
                }
                else
                {
                    responseMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }
            }
            _fakeResponses.Add(uri, responseMessage);
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var emptyContent = string.Empty;
            if (request.Content.Headers.ContentType.MediaType == "application/xml")
                emptyContent = "<empty />";
            
            return Task.FromResult(_fakeResponses.ContainsKey(request.RequestUri) ?
                _fakeResponses[request.RequestUri] :
                new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    RequestMessage = request,
                    Content = new StringContent(emptyContent)
                });
        }
    }
