    Module m = Assembly.GetEntryAssembly().GetModules()[0];
    using (var cert = m.GetSignerCertificate())
    using (var cert2 = new X509Certificate2(cert))
    {
       var _clientHandler = new HttpClientHandler();
       _clientHandler.ClientCertificates.Add(cert2);
       _clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
       var myModel = new Dictionary<string, string>
       {
           { "property1","value" },
           { "property2","value" },
       };
       using (var content = new FormUrlEncodedContent(myModel))
       using (var _client = new HttpClient(_clientHandler))
       using (HttpResponseMessage response = _client.PostAsync($"{url}/{controler}/{action}", content).Result)
       {
           response.EnsureSuccessStatusCode();
           string jsonString = response.Content.ReadAsStringAsync().Result;
           var myClass = JsonConvert.DeserializeObject<MyClass>(jsonString);
        }
    }
