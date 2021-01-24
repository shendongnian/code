    public class ServiceRouteHandler : IRouteHandler
    {
        private readonly string virtualPath;
        private readonly WebServiceHandlerFactory handlerFactory = new WebServiceHandlerFactory();
        public ServiceRouteHandler(string virtualPath)
        {
            if (virtualPath == null)
                throw new ArgumentNullException(nameof(virtualPath));
            if (!virtualPath.StartsWith("~/"))
                throw new ArgumentException("Virtual path must start with ~/", "virtualPath");
            this.virtualPath = virtualPath;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            // Strip the query string (if any) off of the file path
            string filePath = virtualPath;
            int qIndex = filePath.IndexOf('?');
            if (qIndex >= 0)
                filePath = filePath.Substring(0, qIndex);
            // Note: can't pass requestContext.HttpContext as the first 
            // parameter because that's type HttpContextBase, while 
            // GetHandler expects HttpContext.
            return handlerFactory.GetHandler(
                HttpContext.Current, 
                requestContext.HttpContext.Request.HttpMethod,
                virtualPath, 
                requestContext.HttpContext.Server.MapPath(filePath));
        }
    }
