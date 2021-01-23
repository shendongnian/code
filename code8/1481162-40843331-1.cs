    public AddClaimsAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
         var principal = actionExecutedContext.ActionContext.RequestContext.Principal as ClaimsPrincipal;
        if (principal != null)
        {
            var claims = principal.Claims.Select(x => x.Type + ":" + x.Value).ToList();
            actionExecutedContext.Response.Content.Headers.Add("Claims",
               String.Join(",", claims));
        }
                
    }
