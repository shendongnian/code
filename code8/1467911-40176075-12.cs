    internal Task<string> LoadCompanyContracts(string URL)
    {
        ....
        using(var wc = new WebClient())
        {
            return wc.DownloadStringTaskAsync(new Uri(URL))
                     .ConfigureAwait(false);
        }
    }
