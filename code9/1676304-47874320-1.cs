    public async Task<string> HttpClient_Request(string RequestURL)
    {
       string _responseHtml = string.Empty;
       ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | 
                                              SecurityProtocolType.Tls11 | 
                                              SecurityProtocolType.Tls12;
       try
       {
          using (HttpRequestMessage _requestMsg = new HttpRequestMessage())
          {
             _requestMsg.Method = HttpMethod.Get;
             _requestMsg.RequestUri = new Uri(RequestURL);
    
             using (HttpResponseMessage _response = await Http_Client.SendAsync(_requestMsg))
             {
                using (HttpContent _content = _response.Content)
                {
                   _responseHtml = await _content.ReadAsStringAsync();
                };
             };
          };
       }
       catch (HttpRequestException eW)
       {
          Console.WriteLine("Message: {}  Source: {1}", eW.Message, eW.Source);
       }
       catch (Exception eX)
       {
          Console.WriteLine("Message: {}  Source: {1}", eX.Message, eX.Source);
       }
       return _responseHtml;
    }
