    using (WebClient client = new WebClient())
    {
        var query = "p=Products&ctg_id=2000&sort_type=rel-desc&view=0&page=1";
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        client.Headers.Add("accept", "text/html");
        NameValueCollection queries = new NameValueCollection();
        queries.Add("query", query);
        var htmlCode = client.DownloadString("https://www.eganba.com/?p=Products&ctg_id=2000&sort_type=rel-desc&view=0&page=1");
        var result = htmlCode.Contains("Stokta var") ? true : false;
    }
