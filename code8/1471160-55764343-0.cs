    public static IHttpContextAccessor GetHttpContext(string incomingRequestUrl, string host)
        {
            var context = new DefaultHttpContext();
            context.Request.Path = incomingRequestUrl;
            context.Request.Host = new HostString(host);
            //Do your thing here...
            var obj = new HttpContextAccessor();
            obj.HttpContext = context;
            return obj;
        }
