    public static class JsonStringResultExtension {
       public static CustomJsonStringResult JsonString(this ApiController controller, string jsonContent, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var result = new CustomJsonStringResult(controller.Request, statusCode, jsonContent);
            return result;
        }
        public class CustomJsonStringResult : IHttpActionResult {
            private string json;
            private HttpStatusCode statusCode;
            private HttpRequestMessage request;
            public CustomJsonStringResult(HttpRequestMessage httpRequestMessage, HttpStatusCode statusCode = HttpStatusCode.OK, string json = "") {
                this.request = httpRequestMessage;
                this.json = json;
                this.statusCode = statusCode;
            }
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
                return Task.FromResult(Execute());
            }
            private HttpResponseMessage Execute() {
                var response = request.CreateResponse(statusCode);
                response.Content = new StringContent(json, Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
