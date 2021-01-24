    public async Task<string> GetResponseBodyForTelemetry(HttpContext context)
    {
        Stream originalBody = context.Response.Body;
            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;
                    //await the responsebody
                    await next(context);
                    if (context.Response.StatusCode == 204)
                    {
                        return null;
                    }
                    memStream.Position = 0;
                    var responseBody = new StreamReader(memStream).ReadToEnd();
                    //make sure to reset the position so the actual body is still available for the client
                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                    return responseBody;
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
