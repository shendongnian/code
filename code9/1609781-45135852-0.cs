    private static Uri dummy = new Uri("http://dummy/");
    public static string AddQueryStringIfNotExists(string url, string parameter, string value)
    {
        var uri = new Uri(url, UriKind.RelativeOrAbsolute);
        var uriBuilder = uri.IsAbsoluteUri ? new UriBuilder(url) : new UriBuilder(new Uri(dummy, url));
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        if (query[parameter] == null)
        {
            query[parameter] = value;
            uriBuilder.Query = query.ToString();
        }
        return uri.IsAbsoluteUri ? uriBuilder.ToString() : dummy.MakeRelativeUri(new Uri(uriBuilder.ToString())).ToString();
    }
