    public static class RequestExtension
    {
        public static string MapHttpPath(this HttpRequest currentRequest, string path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            path = path.Replace("~", "");
            if (path.StartsWith("/"))
                path = path.Substring(1, path.Length - 1);
            return string.Format("{0}://{1}{2}/{3}",
                currentRequest.Url.Scheme,
                currentRequest.Url.Authority,
                System.Web.HttpRuntime.AppDomainAppVirtualPath == "/" ? "" : System.Web.HttpRuntime.AppDomainAppVirtualPath,
                path);
        }
    }
