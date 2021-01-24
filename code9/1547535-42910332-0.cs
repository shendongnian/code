    public string EmailReplyAll(AuthenticationResult result, string uriString, string msgBody)
     {
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
      EmailReplyAll replyAll = new EmailReplyAll();
      replyAll.Comment = msgBody;
      var jsonData = JsonConvert.SerializeObject(replyAll);
      var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
      try
       {
        HttpResponseMessage response = httpClient.PostAsync(uriString, content).Result;
        var apiResult = response.Content.ReadAsStringAsync().Result;
       }
       catch (Exception exception)
        {
         return "Error";
        }       
         return apiResult;
     }
