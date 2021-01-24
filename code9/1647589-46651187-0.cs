    public string GetBasePath()
    {
        var uri = System.Web.HttpContext.Current.Request.Url;
        var vpa = System.Web.HttpRuntime.AppDomainAppVirtualPath;
        url = string.Format("{0}://{1}{2}", uri.Scheme, uri.Authority, vpa == "/" ? string.Empty : vpa);
        
        return url;
    }
