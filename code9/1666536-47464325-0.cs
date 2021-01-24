    if (!IsMultipartContentType(context.Request.ContentType))
    {
        await context.Response.WriteAsync("Unexpected error.");  
        // Here you're calling the next middleware after writing to the response stream!
        await _next(context);              
        return;
    }
