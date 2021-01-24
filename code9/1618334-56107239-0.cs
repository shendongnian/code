      string result = await DependencyService.Get<IServerCommunication> 
      ().GetFromServerAsync(URL);
       public async Task<string> GetFromServerAsync(string URL)
       {
        HttpClient client = await PreparedClientAsync();
        HttpResponseMessage response;
        try
        {
        response = await client.GetAsync(new Uri(URL));
        IBuffer buffer = await response.Content.ReadAsBufferAsync();
        DataReader reader = DataReader.FromBuffer(buffer);
        byte[] fileContent = new byte[reader.UnconsumedBufferLength];
        reader.ReadBytes(fileContent);
        string result = Encoding.UTF8.GetString(fileContent, 0, fileContent.Length);
        return result;
        }
        catch (Exception ex)
        {
        return "error";
        }
        }
      private async Task<HttpClient> PreparedClientAsync()
      {
       var filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
       filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
       filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
       filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
        HttpClient client = new HttpClient(filter);
        //I also handle other stuff here (client certificate, authentification), but the 
        lines above should allow the Httpclient to accept all certificates
        return client;
       }
