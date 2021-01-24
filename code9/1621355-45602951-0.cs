    public class NotFoundMiddleware : OwinMiddleware
    {
        public NotFoundMiddleware(OwinMiddleware next) : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);
            if (context.Response.StatusCode == (int)HttpStatusCode.NotFound
                && !context.Response.Headers.ContainsKey("X-ServiceFabric")
            )
                context.Response.Headers.Add("X-ServiceFabric", new[] { "ResourceNotFound" });
        }
    }
