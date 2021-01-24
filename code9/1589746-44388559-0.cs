    [HttpPost]
    public HttpResponseMessage UpdateUserData(User user)
    {                            
        try
        {
            // Validate user 
            // if invalid request return Request.CreateErrorResponse(HttpStatusCode.BadRequest, validationErrorMessage);
            //Code to change user
            user.Update();
            return Request.CreateResponse(HttpStatusCode.Created, user);
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogException(ex);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error");
        }
    }
