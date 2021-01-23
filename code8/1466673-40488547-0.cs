        /// <summary>
        /// Recognizes common repository exceptions and creates a corresponding error response.
        /// </summary>
        /// <param name="request">The request to which the response should be created.</param>
        /// <param name="ex">The exception to handle.</param>
        /// <returns>An error response containing the status code and exception data, or null if this is not a common exception.</returns>
        private HttpResponseMessage CreateResponse(HttpRequestMessage request, Exception ex)
        {
            string message = ex.Message;
            HttpStatusCode code = 0;
            if      (ex is KeyNotFoundException)        code = HttpStatusCode.NotFound;
            else if (ex is ArgumentException)           code = HttpStatusCode.BadRequest;
            else if (ex is InvalidOperationException)   code = HttpStatusCode.BadRequest;
            else if (ex is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            else if (ex is HttpException)
            {
                // HttpExceptions are thrown when request between IdentityServer and the API server have failed.
                // IdentityServer has generated an error, the API server received it and now it needs to relay it back to the client.
                var httpException = (HttpException) ex;
                code    = (HttpStatusCode) httpException.ErrorCode;
                message = httpException.Message;
            }
    #if !DEBUG
            // For security reasons, when an exception is not handled the system should return a general error, not exposing the real error information
            // In development time, the programmer will need the details of the error, so this general message is disabled.
            else
            {
                code = HttpStatusCode.InternalServerError;
                message = Errors.InternalServerError;
            }
    #endif
            
            // For some reason the request.CreateErrorResponse() method ignores the message given to it and parses its own message.
            // The error response is constructed manually.
            var content = new { Message = message };
            return new HttpResponseMessage(code)
            {
                ReasonPhrase = message,
                RequestMessage = request,
                Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter())
            };
        }
