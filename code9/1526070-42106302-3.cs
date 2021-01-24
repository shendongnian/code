    var handler = new HttpClientHandler
    {
    	AllowAutoRedirect = true,
    	CookieContainer = new CookieContainer(),
    	UseCookies = true,
    	AutomaticDecompression = DecompressionMethods.Deflate
    };
    
    var client = new HttpClient(handler)
    {
    	Timeout = new TimeSpan(0, 3, 0)
    };
    
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
    client.DefaultRequestHeaders.ExpectContinue = false;
    client.DefaultRequestHeaders.Add("Accept-Language", "en-US, en");
    
    var result = client.GetAsync("http://www1.bloomingdales.com/shop/search/Pageindex%2CProductsperpage/1%2C180?keyword=women%20tank%20top").Result;
    
    var content = result.Content.ReadAsStringAsync().Result;
    
    Console.Write(content);
