    // Extension method used to add the middleware to the HTTP request pipeline.
        public static class BufferedResponseBodyExtensions
        {
           
            public static IApplicationBuilder UseBufferedResponseBody(this IApplicationBuilder builder)
            {
                return builder.Use(async (context, next) =>
                {
                    using (var bufferStream = new MemoryStream())
                    {
                        var orgBodyStream = context.Response.Body;
                        context.Response.Body = bufferStream;
    
                        await next();//there is running MVC
                       
                        bufferStream.Seek(0, SeekOrigin.Begin);
                        await bufferStream.CopyToAsync(orgBodyStream);    
                        context.Response.Body = orgBodyStream;
                    }
                });
            }
        }
