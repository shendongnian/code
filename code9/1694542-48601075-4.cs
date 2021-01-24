    class AbortUnauthorizedConnectionResult : StatusCodeResult
    {
        public AbortUnauthorizedConnectionResult() : base(401)
        {
        }
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            await base.ExecuteResultAsync(context);
            context.HttpContext.Response.Headers.Add("Content-Length", "0");
            context.HttpContext.Response.Body.Flush();
            context.HttpContext.Abort();
        }
    }
