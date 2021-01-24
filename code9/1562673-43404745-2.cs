    public class ResponseRewindMiddleware {
            private readonly RequestDelegate next;
            public ResponseRewindMiddleware(RequestDelegate next) {
                this.next = next;
            }
            public async Task Invoke(HttpContext context) {
                Stream originalBody = context.Response.Body;
                try {
                    using (var memStream = new MemoryStream()) {
                        context.Response.Body = memStream;
                        await next(context);
                        memStream.Position = 0;
                        string responseBody = new StreamReader(memStream).ReadToEnd();
                        memStream.Position = 0;
                        await memStream.CopyToAsync(originalBody);
                    }
                } finally {
                    context.Response.Body = originalBody;
                }
            } 
      
