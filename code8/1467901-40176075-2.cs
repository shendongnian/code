    internal Task<string> LoadCompanyContracts(string URL)
    {
        ....
        using(var wc = new WebClient())
        {
            return wc.DownloadStringAsync(new Uri(URL))
                     .ConfigureAwait(false);
        }
    }
