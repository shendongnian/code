    protected void Application_Error()
    {
        HttpContext httpContext = HttpContext.Current;
        var exception=Server.GetLastError();
        var httpException = exception as HttpException ?? new HttpException(500, "Internal Server Error", exception);
        var jsonResponse = new
        {
            Message = exception.Message,
            StatusCode = httpException.GetHttpCode(),
            StackTrace=httpException.StackTrace
        };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.ContentEncoding = Encoding.UTF8;
        httpContext.Response.Write(JsonConvert.SerializeObject(jsonResponse));
        httpContext.Response.End();
    }
