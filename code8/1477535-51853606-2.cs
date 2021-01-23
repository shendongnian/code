    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.AspNetCore.Mvc.Filters;
    public class ReadableBodyStreamAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // For ASP.NET 2.1
            // context.HttpContext.Request.EnableRewind();
            // For ASP.NET 3.1
            // context.HttpContext.Request.EnableBuffering();
        }
    }
