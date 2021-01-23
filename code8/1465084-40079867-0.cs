    protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnAuthentication(filterContext);
        }
