    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    
    namespace Sample.Helpers
    {
        public class RouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new ASPDotNetHttpHandler();
            }
        }
    
        public class ASPDotNetHttpHandler : IHttpHandler
        {
            public bool IsReusable
            {
                get
                {
                    return true;
                }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                string product = context.Request.QueryString["isbn"];
                int index = context.Request.Url.AbsoluteUri.IndexOf("bookshop/showproduct.aspx?");
    
                if (!(string.IsNullOrEmpty(product) || index == -1))
                {
                    string newUrl = context.Request.Url.AbsoluteUri.Substring(0, index)+"/" + product;
                    context.Response.Redirect(newUrl, true);
                }
            }
        }
    }
