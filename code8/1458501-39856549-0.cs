    public class NotFoundMiddleware {
        private readonly RequestDelegate _next;
    
        public NotFoundMiddleware(RequestDelegate next) {
            _next = next.EnsureNotNull(nameof(next));
        }
    
        public async Task Invoke(HttpContext context) {
            //let the context go through the pipeline
            await _next.Invoke(context);
            if (context.Response?.StatusCode == StatusCodes.Status404NotFound) {
               //execute your logic on the way out of the pipeline.
            }
        }
    }
