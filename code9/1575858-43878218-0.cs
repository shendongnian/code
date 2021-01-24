    using System;
    using System.Net;
    using System.Net.Http;
    
    public static void Run(TimerInfo myTimer, TraceWriter log)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");    
    
        using (var httpClientHandler = new HttpClientHandler())
        {
            httpClientHandler.AllowAutoRedirect = false;
    
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                log.Info("get async...");
                var task = httpClient.GetAsync("https://auth.bullhornstaffing.com/oauth/authorize?client_id=****type=code&username=*****&password=*****&action=Login");
                task.Wait();
    
                var response = task.Result;
                var httpContent = response.Content;
                log.Info("Result: " + httpContent.Headers.ContentLocation);
    
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    var redirectUrl = httpContent.Headers.ContentLocation;
                    var startIndex = redirectUrl.Query.IndexOf("code=") + 5;
                    var endIndex = redirectUrl.Query.IndexOf("&", startIndex);
                    var authorizationCode = (redirectUrl.Query.Substring(startIndex, endIndex - startIndex));
                }
            }
        }
    }
