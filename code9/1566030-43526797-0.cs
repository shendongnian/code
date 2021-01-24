            _httpClient = new HttpClient(new HttpClientHandler
               {
                   UseProxy = true,
                   Proxy = new WebProxy
                   {
                       Address = new Uri(proxyUrl),
                       BypassProxyOnLocal = false,
                       UseDefaultCredentials = true
                   }
               })
               {
                   BaseAddress = url
               };
