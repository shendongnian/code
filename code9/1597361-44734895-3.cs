    private async Task RedirectToAccessDenied(CookieRedirectContext context)
    {
        if (IsAjaxRequest(context.Request))
        {
            //default path
            context.Response.Headers["Location"] = context.RedirectUri;
            context.Response.StatusCode = 403;
        }
        else if (context.Request.Path.Value.Equals("/Foo/Bar"))
        {
            //custom
            context.Response.Redirect("http://google.com");
        }
        else
        {
            //default path
            context.Response.Redirect(context.RedirectUri);
        }
    }
    private static bool IsAjaxRequest(HttpRequest request)
    {
        if (!string.Equals(request.Query["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal))
            return string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal);
            
        return true;
    }
