    public class HttpRequestMessageAccessor : IHttpRequestMessageAccessor {
        const string MS_HttpRequestMessage = "MS_HttpRequestMessage";
        public HttpRequestMessage Request {
            get {
                HttpRequestMessage request = null;
                if (HttpContext.Current != null && HttpContext.Current.Items.Contains(MS_HttpRequestMessage)) {
                    request = HttpContext.Current.Items[MS_HttpRequestMessage] as HttpRequestMessage;
                }
                return request;
            }
        }
    }
