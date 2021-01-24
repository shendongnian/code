    public class RequestDeCompressFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var request = actionContext.Request;
            if (request.Content.Headers.ContentEncoding.Contains("GZIP"))
            {
                await request.Content.LoadIntoBufferAsync().ConfigureAwait(false);
                request.Content = new HttpGZipContent(await request.Content.ReadAsByteArrayAsync().ConfigureAwait(false), System.IO.Compression.CompressionMode.Decompress);
            }
           //TODO: compress the response, you could follow http://www.intstrings.com/ramivemula/articles/jumpstart-47-gzipdeflate-compression-in-asp-net-mvc-application/
           await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {   
            //you could also compress the response here
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
