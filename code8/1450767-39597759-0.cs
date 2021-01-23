    public async Task<string> ProcessURLAsync(string url, ExtendedWebClient oExtendedWebClient, string sParam)
    {
        string result = "";
        while (!result.Contains("Start"))
        {
            ExtendedWebClient oClient = new ExtendedWebClient(false);
            oClient.CookieContainer = oExtendedWebClient.CookieContainer;
            oClient.LastPage = "https://www.example.co.in/test/getajax.jsf";
            byte[] PostData = System.Text.Encoding.ASCII.GetBytes(sParam);
            Headers.Add("User-Agent", "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            oClient.Headers.Remove("X-Requested-With");
            oClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
            var byteArray = await oClient.UploadDataTaskAsync(url, PostData);
            string result = System.Text.Encoding.UTF8.GetString(byteArray);
        }
        return result;
    }
