     var address = new Uri(ConfigurationReader.AuthenticationUrl);
     var request = WebRequest.Create(address) as HttpWebRequest;
     request.Method = "POST";
     request.ContentType = "application/json";
     var requestObject = new AuthRequest()
     {
           domain = ConfigurationReader.AuthDomain,
           userName = username,
           password = password,
           returnUrl = string.Empty,
           authenticationType = ConfigurationReader.AuthType
      };
      var requestJson = JsonConvert.SerializeObject(requestObject);
      var byteData = Encoding.UTF8.GetBytes(requestJson);
      request.ContentLength = byteData.Length;
      using (Stream requestStream = request.GetRequestStream())
      {
            requestStream.Write(byteData, 0, byteData.Length);
      }
      using (var response = request.GetResponse() as HttpWebResponse)
      {
           var reader = new StreamReader(response.GetResponseStream());
           return JsonConvert.DeserializeObject<AuthResponse>(reader.ReadToEnd());
       } 
