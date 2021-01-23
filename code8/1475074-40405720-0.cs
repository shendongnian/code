    public string GetHtml(string url)
    {
        using (var wc = new WebClient())
        {
            return wc.DownloadString(url);
        }
    }
