    public class OwinExceptionHandlerMiddleware : OwinMiddleware
    {
        private readonly ILogger logger;
        public OwinExceptionHandlerMiddleware(OwinMiddleware next, ILogger logger)
            : base(next)
        {
            this.logger = logger;
        }
        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await this.Next.Invoke(context);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{nameof(OwinExceptionHandlerMiddleware)} caught exception.");
                throw;
            }
        }
    }
