    [RestResource(BasePath = "/RestService/")]
    public class MyRestResources
    {
        public IHttpContext ManuallyRegisterMe(IHttpContext context)
        {
            return context;
        }
        [RestRoute(PathInfo = "/autodiscover")]
        public IHttpContext AutoDiscoverMe(IHttpContext context)
        {
            return context;
        }
    }
