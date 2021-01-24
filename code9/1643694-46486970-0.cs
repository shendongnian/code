    private string GetClientIpAddress (HttpRequestMessage request)
            {
            if ( request.Properties.ContainsKey("MS_HttpContext") )
                {
                return ((HttpContextWrapper) request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                }
            if ( request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name) )
                {
                var prop = (RemoteEndpointMessageProperty) request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
                }
            if ( request.Headers.Contains("X-Forwarded-For") )
                {
                return request.Headers.GetValues("X-Forwarded-For").FirstOrDefault();
                }
            // Self-hosting using Owin. Add below code if you are using Owin communication listener
            if ( request.Properties.ContainsKey("MS_OwinContext") )
                {
                var owinContext = (OwinContext) request.Properties["MS_OwinContext"];
                if ( owinContext?.Request != null )
                    {
                    return owinContext.Request.RemoteIpAddress;
                    }
                }
            if ( HttpContext.Current != null )
                {
                return HttpContext.Current.Request.UserHostAddress;
                }
            return null;
            }
