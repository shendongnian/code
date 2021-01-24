        HttpMessageHandler handler = new HttpClientHandler
                        {
                            SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls,
                            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                        };
    var httpClient = new HttpClient(handler);
        httpClient.Timeout = TimeSpan.FromMinutes(60);
            httpClient.BaseAddress = new Uri("https://onpremise");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Simple Get Request to test on-premise service
            var response = await httpClient.GetStringAsync("api/OnPremiseData/GetData");
            ViewBag.ResponseText = response;
