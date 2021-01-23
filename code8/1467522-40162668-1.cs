    public class JsonStreamHttpActionResult<T> : IHttpActionResult
    {
        private T responseData;
        private HttpRequestMessage request;
        public JsonStreamHttpActionResult(HttpRequestMessage request, T responseData)
        {
            this.responseData = responseData;
            this.request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = request.CreateResponse(System.Net.HttpStatusCode.OK);
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
