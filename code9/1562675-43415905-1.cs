    /// <summary>
    /// Invoke the middleware.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context)
    {
        if (!_provider.CheckRequestAcceptsCompression(context))
        {
            await _next(context);
            return;
        }
        var bodyStream = context.Response.Body;
        var originalBufferFeature = context.Features.Get<IHttpBufferingFeature>();
        var originalSendFileFeature = context.Features.Get<IHttpSendFileFeature>();
        var bodyWrapperStream = new BodyWrapperStream(context, bodyStream, _provider,
            originalBufferFeature, originalSendFileFeature);
        context.Response.Body = bodyWrapperStream;
        context.Features.Set<IHttpBufferingFeature>(bodyWrapperStream);
        if (originalSendFileFeature != null)
        {
            context.Features.Set<IHttpSendFileFeature>(bodyWrapperStream);
        }
        try
        {
            await _next(context);
            // This is not disposed via a using statement because we don't want to flush the compression buffer for unhandled exceptions,
            // that may cause secondary exceptions.
            bodyWrapperStream.Dispose();
        }
        finally
        {
            context.Response.Body = bodyStream;
            context.Features.Set(originalBufferFeature);
            if (originalSendFileFeature != null)
            {
                context.Features.Set(originalSendFileFeature);
            }
        }
    }
    
