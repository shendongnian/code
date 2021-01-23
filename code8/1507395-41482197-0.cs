    public static class ApiControllerExtensions
    {
        public static IHttpActionResult InvalidRequest(this ApiController apiController, string error, string errorDetails = "", ModelStateDictionary modelState = null)
        {
            var err = modelState != null ? new HttpError(modelState, false) : new HttpError();
            if (err.ContainsKey("message"))
                err.Remove("message");
            err["error"] = error;
            if (!string.IsNullOrWhiteSpace(errorDetails))
                err["error_description"] = errorDetails;
            var response = apiController.Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
    
            return new ResponseMessageResult(response);
        }
    
        public static IHttpActionResult InvalidRequest(this ApiController apiController, string error, ModelStateDictionary modelState = null)
        {
            return InvalidRequest(apiController, error, null, modelState);
        }
    }
