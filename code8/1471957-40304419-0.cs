    public class RequestInformation : IRequestInformation
    {
        private readonly HttpContext context;
        public RequestInformation(IHttpContextAccessor contextAccessor) 
        {
            // Don't forget null checks
            this.context = contextAccessor.HttpContext;
        }
        public string Host
        {
            get { return this.context./*Do whatever you need here*/; }
        }
    }
