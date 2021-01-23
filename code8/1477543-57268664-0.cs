    public class EnableRequestRewindMiddleware
    {
        private readonly RequestDelegate _next;
        ///<inheritdoc/>
        public EnableRequestRewindMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableRewind();
            await _next(context);
        }
    }
