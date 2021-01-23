    public class JsonStreamHttpActionResult<T> : IHttpActionResult
    {
        private T responseData;
        private HttpRequestMessage request;
        private HttpStatusCode statusCode;
        public JsonStreamHttpActionResult(HttpRequestMessage request, System.Net.HttpStatusCode code, T responseData)
        {
            this.responseData = responseData;
            this.request = request;
            this.statusCode = code;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = request.CreateResponse(statusCode);
            response.Content =
                    new PushStreamContent((stream, content, context) =>
                    {
                        var serializer = new Newtonsoft.Json.JsonSerializer();
                        using (var writer = new System.IO.StreamWriter(stream))
                        {
                            serializer.Serialize(writer, responseData);
                            stream.Flush();
                        }
                    });
            return Task.FromResult(response);
        }
    }
