    private static string WebRequest(string UrlToQuery)
    {
        using(WebClient client = new WebClient)
        {
            return client.DownloadString(UrlToQuery);
        }
    }
