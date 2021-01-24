    public class AccountService {
        private readonly IHttpRequestMessageAccessor accessor;
        public AccountService(IHttpRequestMessageAccessor accessor) {
            this.accessor = accessor;
        }
        public async Task<HttpResponseMessage> FunctionalGetAccount() {
            var globalRequest = accessor.Request;
            var request = new HttpRequest(globalRequest);
            //...code removed for brevity
            var newHttpResponse = CreateResponse(response, httpStatusCode);
            return newHttpResponse;
        }
    }
