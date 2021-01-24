    private void UnhandeledException(ExceptionContext context)
    {
        context.Exception.Ship("API_KEY", new System.Guid("LOG_ID"), context.HttpContext);
        var msg = context.Exception.GetBaseException().Message;
        string stack = context.Exception.StackTrace;
        _apiError = new ApiError(msg) { Detail = stack };
        context.HttpContext.Response.StatusCode = 500;
    }
