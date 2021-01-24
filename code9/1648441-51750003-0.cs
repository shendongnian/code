    private static ActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
    {
        StatusCode = (int)statusCode,
        Content = $"Status Code: {(int)statusCode}; {statusCode}; {reason}",
        ContentType = "text/plain",
    };
