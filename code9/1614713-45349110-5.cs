    public class HttpRequestMessageAccessor : IHttpRequestMessageAccessor {
        public HttpRequestMessage Request {
            get {
                HttpRequestMessage request = null;
                if (GlobalRequestMessageHandler.CurrentRequest != null) {
                    request = GlobalRequestMessageHandler.CurrentRequest.Value;
                }
                return request;
            }
        }
    }
