    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new ApiResponse(false, ApiErrorMessages.Unauthorized, ErrorType.Unauthorized));
            }
