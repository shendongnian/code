    if (routeValues != null)
    {
        var memoryStream = new MemoryStream();
        routeValues.HttpContext.Request.Body.CopyTo(memoryStream);
        // reset position after CopyTo
        memoryStream.Seek(0, SeekOrigin.Begin);
        var obj = StreamToObject(memoryStream);
        // reset position after ReadToEnd
        memoryStream.Seek(0, SeekOrigin.Begin);
        routeValues.HttpContext.Request.Body = memoryStream;
        context.Succeed(requirement);
    }
