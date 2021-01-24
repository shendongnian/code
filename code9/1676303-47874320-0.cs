    private void HttpClient_Setup()
    {
       Http_Handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
       Http_Handler.AllowAutoRedirect = false;
       Http_Handler.CookieContainer = HttpClCookieJar;
       Http_Handler.UseCookies = true;
       Http_Handler.UseDefaultCredentials = true;
       Http_Client.Timeout = new TimeSpan(30000);
       Http_Client = new HttpClient(Http_Handler);
       Http_Client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0");
       Http_Client.DefaultRequestHeaders.Add("Accept-Language", "it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3");
       Http_Client.DefaultRequestHeaders.Add("Accept", "*/*");
       Http_Client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
    }
