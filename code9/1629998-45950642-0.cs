    public class CustomApiException : Exception
    {
        /// <summary>
        /// Optional application-specific error code returned to the client.
        /// </summary>
        public int? ApplicationErrorCode { get; private set; } = null;
        /// <summary>
        /// HTTP status code returned to the client.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.BadRequest;
        public CustomApiException() : base() { }
        public CustomApiException(string message) : base(message) { }
        public CustomApiException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        public CustomApiException(string message, HttpStatusCode httpStatusCode, int? applicationErrorCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ApplicationErrorCode = applicationErrorCode;
        }
        public CustomApiException(string message, int? applicationErrorCode) : base(message)
        {
            ApplicationErrorCode = applicationErrorCode;
        }
    }
