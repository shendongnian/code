    using (var handler = new HttpClientHandler())
    {
        handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
        using (HttpClient client = new HttpClient(handler))
        {
            string requestObjJson = requestObj.ToJson();
            var address = new Uri($"https://yourcompany.com/");
            string token = GetToken();
            client.BaseAddress = address;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var contentData = new StringContent(requestObjJson, System.Text.Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("yourcompany/new-employee", contentData))
            {
                var content = response.Content.ReadAsStringAsync();
                var taskResult = content.Result;
                JObject resultObj = JObject.Parse(taskResult);
                return resultObj;
            }
        }
    }
