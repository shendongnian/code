    public class SetupWebApiResponse
    {
        public SetupWebApiResponse() { }
        public SetupWebApiResponse(int statusCode, object responseBody)
        {
            this.StatusCode = statusCode;
            this.ResponseBody = responseBody;
        }
        public SetupWebApiResponse(HttpStatusCode statusCode, object responseBody)
            : this((int)statusCode, responseBody)
        {
        }
        /// <summary>
        /// Gets or sets the HTTP status code of the response
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the response body content
        /// </summary>
        public object ResponseBody { get; set; }
    }
