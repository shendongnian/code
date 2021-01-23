    public List<string> GetLinks(List<string> urls, int depth){
        var newUrls = new List<string>();
        if(depth == 0) return newUrls ;
        foreach(var url in urls){
             newUrls.AddRange(scrape(url));
        }
        return urls.AddRange(GetLinks(newUrls, depth - 1);
    }
