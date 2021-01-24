        using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
        
        
        namespace WebApplication1.Models
        {
            public class AuthorizeFilter : AuthorizeAttribute
            {
                public bool verifyToken(string token)
                {
                    return false;
                }
                protected override bool AuthorizeCore(HttpContextBase httpContext)
                {
        
                    // Get the headers
                    var headers = httpContext.Request.Headers;
                    //your token verification 
                    if (verifyToken(headers["SomeHeader"]))
                    {
                        return true;
                    }
                    return false;
        
                }
        
        
        
                protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
                {
                    try
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Home", action = "NotAuthorzied" }));
                    }
                    catch (Exception ex)
                    {
        
                    }
                }
            }
        }
