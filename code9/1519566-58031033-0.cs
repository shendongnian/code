            using (var client = new HttpClient(
                    HttpClientFactory.CreatePipeline(
                    new HttpClientHandler
                    {
                        CookieContainer = new CookieContainer(),
                        UseCookies = true
                    },
                    new DelegatingHandler[] { new CustomHandler() })))
            {
                var content = new StringContent(request, Encoding.UTF8,"text/xml");
                using (var response = await client.PostAsync(requestUrl, content))
                {
                    // DO response processing
                }
            }
