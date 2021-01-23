    public class StatusCodeException : Exception
    {
        public StatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; set; }
    }
