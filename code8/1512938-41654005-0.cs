    public static async Task<SearchResult[]> StartSearch(string str)
    {
        List<Task<SearchResult>> taskList = new List<Task<SearchResult>>();
        
        foreach (var url in TheWeb.URLs)
        {
            System.Console.WriteLine("Searching URL {0}", url);
            taskList.Add(SearchWebsiteAsync(url, str));
        }
    
        return await Task.WhenAll<SearchResult>(taskList);
    }
