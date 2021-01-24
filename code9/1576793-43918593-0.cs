    public class IpMiddleware : OwinMiddleware
    {
        private readonly IpOptions _options;
        public IpMiddleware(OwinMiddleware next, IpOptions options) : base(next)
        {
            this._options = options;
            this.Next = next;
        }
        public override async Task Invoke(IOwinContext context)
        {
            context.Request.RemoteIpAddress = _options.RemoteIp;
            await this.Next.Invoke(context);
        }
    }
