    public class CheckHeaderFilter : Attribute, IResourceFilter
    {
        private readonly string[] _headers;
        public CheckHeaderFilter(params string[] headers)
        {
            _headers = headers;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (_headers == null) return;
            
            if (!_headers.All(h => context.HttpContext.Request.Headers.ContainsKey(h)))
            {
                throw new Exception("Necessary HTTP headers not present!");
                //do whatever you need to do when check fails
            }
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }
    }
