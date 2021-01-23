    private List<List<string>> GroupedNodes(string URL, params string[] XPathes)
    {
        //Load HTML Source
        HtmlWeb loader = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = loader.Load(URL);
    
        //some other codes ...
    
        //Return result as a List of list
        return grouped;
    }
    
    public Task<List<List<string>>> GroupedNodesAsync(string URL, params string[] XPathes)
    {
        return Task.Run(() => GroupedNodes(URL, XPathes));
    }
