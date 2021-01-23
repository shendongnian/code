    namespace My.Web.Filters
    {
        using System.Collections.Generic;
        using System.Linq;
        using System.Net;
        using Microsoft.AspNetCore.Mvc;
        using Microsoft.AspNetCore.Mvc.Filters;
        using NetTools;
        using My.Web.Configuration;
    
        public class ClientIPAddressFilterAttribute : ActionFilterAttribute
        {
            private readonly IEnumerable<IPAddressRange> authorizedRanges;
    
            public ClientIPAddressFilterAttribute(IIPWhitelistConfiguration configuration)
            {
                this.authorizedRanges = configuration.AuthorizedIPAddresses
                    .Select(item => IPAddressRange.Parse(item));
            }
    
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var clientIPAddress = context.HttpContext.Connection.RemoteIpAddress;
                if (!this.authorizedRanges.Any(range => range.Contains(clientIPAddress)))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
        }
