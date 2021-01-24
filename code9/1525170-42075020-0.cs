    public class ErrorResult : IHttpActionResult {
        public ErrorResult(HttpRequestMessage request, string message, HttpStatusCode status = HttpStatusCode.InternalServerError, string reasonPhrase = "Internal Server Error") {
            ReasonPhrase = reasonPhrase;
            Request = request;
            Message = message;
            Status = status;
        }
        public HttpStatusCode Status { get; private set; }
        public string ReasonPhrase { get; private set; }
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) {
            return Task.FromResult(Execute());
        }
        private HttpResponseMessage Execute() {
            var status = Status;
            var responseBody = new Models.envelope {
                meta = new Models.metadata {
                    code = (int)status,
                    type = ReasonPhrase ?? status.ToString().ToCamelCase(),
                    message = Message
                },
                data = null
            };
            var response = Request.CreateResponse(status, responseBody);
            response.RequestMessage = Request;
            response.ReasonPhrase = ReasonPhrase;
            return response;
        }
    }
