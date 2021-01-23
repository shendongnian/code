    internal async Task<string> LoadCompanyContracts(string URL)
    {
        ....
        using(var wc = new WebClient())
        {
            string tmp = await wc.DownloadStringTaskAsync(new Uri(URL));
            return tmp;
        }
    }
